#ifndef CSVPARSER_H
#define CSVPARSER_H
#include <QString>
#include <QFile>
#include <QIODevice>
#include <QTextStream>
#include <vector>

typedef QList<QList<QString> > dataList;
typedef QList<QString> headerList;
class CsvParser
{
public:
    CsvParser(QString filename);

    dataList getData();

private:
    dataList contentData;
    headerList headerData;

    void parseHeader(QString firstline);
    void parseData(QString data);

};

#endif // CSVPARSER_H
