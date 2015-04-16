#-------------------------------------------------
#
# Project created by QtCreator 2015-04-16T08:28:04
#
#-------------------------------------------------

QT       += core gui printsupport

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = Meteo
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    csvparser.cpp \
    qcustomplot.cpp \
    meteomodel.cpp

HEADERS  += mainwindow.h \
    csvparser.h \
    qcustomplot.h \
    meteomodel.h

FORMS    += mainwindow.ui
