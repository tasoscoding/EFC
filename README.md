Energy Flow Control
===================

## Intro
EFC is an experimental project created at the Electric Drives laboratory of the School of Electrical and Computer Engineering at the National Technical University of Athens.
Its aim is to explore control of industrial machines using smart electronics and the cloud.

Related paper here: https://www.mdpi.com/1996-1073/16/7/3049

### Contents
This repository hosts the code that controls the local machine, i.e. the Raspberry Pi, which is in charge of controlling the inverter, and ultimately the machines.

The repository that manages the cloud infrastructure can be found here: https://github.com/tasoscoding/efcv2.

#### PoC.DesktopApp
This project is an initial proof of concept that an inverter can be controlled by a computer using a serial protocol. It is a Windows Forms desktop app, and uses a sample Modbus implementation in C# (by distantcity @ codeproject, https://www.codeproject.com/articles/20929/simple-modbus-protocol-in-c-net).

#### PoC.UWP
Same as above, but uses the Universal Windows Platform framework.
