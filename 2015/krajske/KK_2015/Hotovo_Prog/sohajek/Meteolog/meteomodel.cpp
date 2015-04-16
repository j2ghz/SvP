#include "meteomodel.h"

MeteoModel::MeteoModel(dataList data) {
    this->rawData = data;
}

dataList MeteoModel::filterYears(int yearStart, int yearEnd) {
    dataList filteredDataYears;

    // Filter years
    for (int i = 1; i < this->rawData.length(); i++) {
        int year = this->rawData.at(i).at(0).toInt();
        if (year < yearStart || year > yearEnd) {
            continue;
        }
        filteredDataYears.append(this->rawData[i]);
    }
    return filteredDataYears;
}

dataList MeteoModel::filterWeeks(int weekStart, int weekEnd, dataList filteredDataYears) {
    dataList filteredData;

    //Filter weeks
    for (int i = 0; i < filteredDataYears.length(); i++) {
        int week = filteredDataYears.at(i).at(1).toInt();
        if (week < weekStart || week > weekEnd) {
            continue;
        }
        filteredData.append(this->rawData[i]);
    }
    return filteredData;
}

void MeteoModel::parseBetweenYearsWeeks(int yearStart, int yearEnd, int weekStart, int weekEnd) {
    this->filtData = this->filterWeeks(weekStart, weekEnd, this->filterYears(yearStart, yearEnd));
}

int MeteoModel::getMaxToIndex(int index) {
    int maxVal = 0;
    if (index > this->filtData.length()) {
        return NULL;
    }
    for (int i = 0; i < this->filtData.length(); i++) {
        if (i > index) {
            break;
        }
        if (this->filtData.at(i).at(2).toInt() > maxVal) {
            maxVal = this->filtData.at(i).at(2).toInt();
        }
    }
    return maxVal;
}

int MeteoModel::getMinToIndex(int index) {
    int minVal = 0;
    if (index > this->filtData.length()) {
        return NULL;
    }
    for (int i = 0; i < this->filtData.length(); i++) {
        if (i > index) {
            break;
        }
        if (this->filtData.at(i).at(2).toInt() < minVal) {
            minVal = this->filtData.at(i).at(2).toInt();
        }
    }
    return minVal;
}

int MeteoModel::getAvgToIndex(int index) {
    QVector<int> numbers;
    if (index > this->filtData.length()) {
        return NULL;
    }
    for (int i = 0; i < this->filtData.length(); i++) {
        if (i > index) {
            break;
        }
        numbers.append(this->filtData.at(i).at(2).toInt());
    }
    int sum = 0;
    int count = numbers.count();
    for (int i = 0; i < numbers.count(); i++) {
        sum += numbers[i];
    }
    return sum / count;
}

returnValue MeteoModel::getMax() {
    returnValue coords;
    for (int i = 0; i < this->filtData.length(); i++) {
        QMap<int, int> coordsH;
        coordsH.insert(this->filtData.at(i).at(1).toInt(), this->getMaxToIndex(i));
        coords.append(coordsH);
    }
    return coords;
}

returnValue MeteoModel::getMin() {
    returnValue coords;
    for (int i = 0; i < this->filtData.length(); i++) {
        QMap<int, int> coordsH;
        coordsH.insert(this->filtData.at(i).at(1).toInt(), this->getMinToIndex(i));
        coords.append(coordsH);
    }
    return coords;
}

returnValue MeteoModel::getAvg() {
    returnValue coords;
    for (int i = 0; i < this->filtData.length(); i++) {
        QMap<int, int> coordsH;
        coordsH.insert(this->filtData.at(i).at(1).toInt(), this->getAvgToIndex(i));
        coords.append(coordsH);
    }
    return coords;
}

returnValue MeteoModel::getMeasured() {
    returnValue coords;
    for (int i = 0; i < this->filtData.length(); i++) {
        QMap<int, int> coordsH;
        coordsH.insert(this->filtData.at(i).at(1).toInt(), this->filtData.at(i).at(2).toInt());
        coords.append(coordsH);
    }
    return coords;
}
