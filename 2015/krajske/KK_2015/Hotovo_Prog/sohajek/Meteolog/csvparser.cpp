#include "csvparser.h"


CsvParser::CsvParser(QString filename) {
    QFile csvFile(filename);
    QString data;
    if (csvFile.open(QIODevice::ReadOnly)) {
        QTextStream in(&csvFile);
        while (!in.atEnd())
        {
           data.append(in.readLine() + "\n");
        }
        csvFile.close();
    }
    this->parseData(data);
}


void CsvParser::parseData(QString data) {
    QStringList splitted = data.split("\n");
    this->parseHeader(splitted[0]);
    for (int i = 1; i < splitted.length(); i++) {
        QList<QString> dataRow = (QList<QString>) splitted[i].split(";");
        this->contentData.append(dataRow);
    }
}

void CsvParser::parseHeader(QString firstline) {
    QStringList splittedLine = firstline.split(";");
    for (int i = 0; i < splittedLine.length(); i++) {
        headerData.append(splittedLine[i]);
    }
}

dataList CsvParser::getData () {
    return this->contentData;
}
