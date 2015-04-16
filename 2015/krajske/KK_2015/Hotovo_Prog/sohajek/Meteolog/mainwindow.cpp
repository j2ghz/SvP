#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <iostream>
QStandardItemModel* model;
MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->browseButton->connect(ui->browseButton, SIGNAL(clicked(bool)), this, SLOT(browseButtonClicked(bool)));
    ui->plotButton->connect(ui->plotButton, SIGNAL(clicked(bool)), this, SLOT(plotButtonClicked(bool)));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::browseButtonClicked(bool) {
    QString filename = QFileDialog::getOpenFileName();
    ui->lineEdit->setText(filename);
}

void MainWindow::plotButtonClicked(bool) {
    CsvParser* csvp = new CsvParser(ui->lineEdit->text());
    MeteoModel* m = new MeteoModel(csvp->getData());
    m->parseBetweenYearsWeeks(ui->minYearEdit->text().toInt(), ui->maxYearEdit->text().toInt(), ui->minWeekEdit->text().toInt(), ui->maxWeekEdit->text().toInt());

    returnValue max = m->getMax();
    this->drawMaxPlot(max);
    returnValue min = m->getMin();
    this->drawMinPlot(min);
    returnValue avg = m->getAvg();
    this->drawAvgPlot(avg);
    returnValue measured = m->getMeasured();
    this->drawMeasuredPlot(measured);

    this->ui->plotArea->xAxis->setRange(0, 300);
    this->ui->plotArea->yAxis->setRange(-300, 300);
    this->ui->plotArea->setInteraction(QCP::iRangeDrag, true);
    this->ui->plotArea->setInteraction(QCP::iRangeZoom, true);
    this->ui->plotArea->legend->setVisible(true);
    this->ui->plotArea->replot();
}

void MainWindow::drawMaxPlot(returnValue max) {
    QVector<double> x(max.length()), y(max.length());
    this->ui->plotArea->addGraph();
    for (int i = 0; i < max.length(); ++i) {
        x.append(i);
        foreach(const int &key, max.at(i).keys()) {
            y.append((double)max.at(i).value(key));
        }
    }

    this->ui->plotArea->graph(0)->setData(x, y);
    this->ui->plotArea->graph(0)->setPen(QPen(Qt::red));
    this->ui->plotArea->graph(0)->setName("Maximal temperature");
    this->ui->plotArea->replot();
}
void MainWindow::drawMinPlot(returnValue min) {
    QVector<double> x(min.length()), y(min.length());
    this->ui->plotArea->addGraph();
    for (int i = 0; i < min.length(); ++i) {
        x.append(i);
        foreach(const int &key, min.at(i).keys()) {
            y.append((double)min.at(i).value(key));
        }
    }
    this->ui->plotArea->graph(1)->setData(x, y);
    this->ui->plotArea->graph(1)->setPen(QPen(Qt::blue));
    this->ui->plotArea->graph(1)->setName("Minimal temperature");
    this->ui->plotArea->replot();
}
void MainWindow::drawAvgPlot(returnValue avg) {
    QVector<double> x(avg.length()), y(avg.length());
    this->ui->plotArea->addGraph();
    for (int i = 0; i < avg.length(); ++i) {
        x.append(i);
        foreach(const int &key, avg.at(i).keys()) {
            y.append((double)avg.at(i).value(key));
        }
    }
    this->ui->plotArea->graph(2)->setData(x, y);
    this->ui->plotArea->graph(2)->setPen(QPen(Qt::green));
    this->ui->plotArea->graph(2)->setName("Average temperature");
    this->ui->plotArea->replot();
}
void MainWindow::drawMeasuredPlot(returnValue measured) {
    QVector<double> x(measured.length()), y(measured.length());
    this->ui->plotArea->addGraph();
    for (int i = 0; i < measured.length(); ++i) {
        x.append(i);
        foreach(const int &key, measured.at(i).keys()) {
            y.append((double)measured.at(i).value(key));
        }
    }
    this->ui->plotArea->graph(3)->setData(x, y);
    this->ui->plotArea->graph(3)->setPen(QPen(Qt::yellow));
    this->ui->plotArea->graph(3)->setName("Measured temperature");
    this->ui->plotArea->replot();
}
