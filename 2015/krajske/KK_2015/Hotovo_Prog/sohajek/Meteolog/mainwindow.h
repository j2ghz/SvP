#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "csvparser.h"
#include "meteomodel.h"
namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    QString filename;
    void drawMinPlot(returnValue min);
    void drawMaxPlot(returnValue max);
    void drawAvgPlot(returnValue avg);
    void drawMeasuredPlot(returnValue measured);
    ~MainWindow();
public slots:
    void browseButtonClicked(bool);
    void plotButtonClicked(bool);

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
