#ifndef METEOMODEL_H
#define METEOMODEL_H
#include "csvparser.h"
#include <QVector>
typedef QList<QMap<int, int> > returnValue;
class MeteoModel
{
public:
    MeteoModel(dataList data);

    dataList filterYears(int yearStart, int yearEnd);
    dataList filterWeeks(int weekStart, int weekEnd, dataList filteredDataYears);
    void parseBetweenYearsWeeks(int yearStart, int yearEnd, int weekStart, int weekEnd);
    returnValue getMax();
    returnValue getMin();
    returnValue getAvg();
    returnValue getMeasured();
    int getMaxToIndex(int index);
    int getMinToIndex(int index);
    int getAvgToIndex(int index);
private:
    dataList rawData;
    dataList filtData;
    returnValue maxTemp;
    returnValue minTemp;
    returnValue avgTemp;
    returnValue measuredTemp;
};

#endif // METEOMODEL_H
