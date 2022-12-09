import time
import matplotlib.pyplot as plt
import os

print(os.listdir(os.getcwd()))
#time.sleep(5000)

fig = plt.figure()
ax = fig.add_subplot(111)

with open("shapeConverter.txt") as f:
    task = f.readline()

figure = task.split('|')[1]
points = figure.split()

x_to_draw = []
y_to_draw = []

xmin, xmax, ymin, ymax = 100000, 0, 1000000, 0

for point in points:
    x = int(point.split(',')[0][1:])
    y = int(point.split(',')[1][:-1])
    x_to_draw.append(x)
    y_to_draw.append(y)
    xmin = min(x, xmin)
    xmax = max(x, xmax)
    ymin = min(y, ymin)
    ymax = max(y, ymax)
'''
cordmin = min(xmin, ymin) - 10
cordmax = max(xmax, ymax) + 10

ax.set_xlim([cordmin, cordmax])
ax.set_ylim([cordmin, cordmax])
'''
plt.scatter(x_to_draw, y_to_draw)
plt.show()
#time.sleep(20000)
f.close()
