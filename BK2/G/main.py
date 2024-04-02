import json
import matplotlib.pyplot as plt

def read_json(filename):
    with open(filename, 'r') as file:
        data = json.load(file)
    return data

def main():
    # Чтение данных из файлов JSON
    cx_chart = read_json('cxChart.json')
    cy_small_chart = read_json('cySmallChart.json')
    cy_avg_chart = read_json('cyAvgChart.json')
    cy_big_chart = read_json('cyBigChart.json')
    px_chart = read_json('pxChart.json')
    py_small_chart = read_json('pySmallChart.json')
    py_avg_chart = read_json('pyAvgChart.json')
    py_big_chart = read_json('pyBigChart.json')

    # Построение графиков
    plt.figure(figsize=(10, 6))

    plt.subplot(2, 1, 1)
    plt.plot(cx_chart, cy_small_chart, label='Small')
    plt.plot(cx_chart, cy_avg_chart, label='Average')
    plt.plot(cx_chart, cy_big_chart, label='Big')
    plt.xlabel('Consumption')
    plt.ylabel('Pressure')
    plt.title('Consumption vs Pressure')
    plt.legend()

    plt.subplot(2, 1, 2)
    plt.plot(px_chart, py_small_chart, label='Small')
    plt.plot(px_chart, py_avg_chart, label='Average')
    plt.plot(px_chart, py_big_chart, label='Big')
    plt.xlabel('Pressure')
    plt.ylabel('Consumption')
    plt.title('Pressure vs Consumption')
    plt.legend()

    plt.tight_layout()
    plt.show()

if __name__ == "__main__":
    main()
