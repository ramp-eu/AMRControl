# FlexMill AMRControl
C# Code for operating the AMR through a Web-interface

FlexMill AMRControl is a project that shall allow user-controlled material transport within a workshop by using an Autonomous Mobile Robot (AMR).
In this repository the code for AMRControl is stored. The project relies on the FEATS-Project from Dalma-Systems, which can be found here: [FEATS](https://github.com/Dalma-Systems/FEATS)

This project is part of [DIH2](http://www.dih-squared.eu/). It also will be added to RAMP, see the [catalogue](https://github.com/ramp-eu).

This project is part of [FIWARE](https://www.fiware.org/). For more information check the [FIWARE Catalogue](https://github.com/Fiware/catalogue/).

# Table of contents
* [Background](#Background)
* [Build and install](#Build-and-install)
* [Documentation](#Documentation)
* [License](#License)

# Background
The complete industrial engineering and production process starting with a 3D model and up to the final part shall be fully automatized including variations of parts and its features. One group of products at RO-RA are adapter ends of Aerostruts, which can vary by geometry, size, material and batch size. At the beginning of this process these parts shall be described by various parameters and this data set of parameters shall automatically trigger all subsequent processes. These processes use different technologies such as CAD, ERP, CAM, NC-Simulation, CAQ (control plan), tool management, AMR, CMM. Further on the FIWARE platform shall be used to handle and process the generated data in each step and to trigger these subprocesses. It shall be emphasized here that the AMR is key for the reduction of non-value adding expenses especially for small batch sizes and will be used as a key part of this experiment. The AMR will be used to autonomously deliver the right tooling to the right machining centres at the right time orchestrated by FIWARE. This is key in agile production so that the system can adapt to variations of parts, which cause variations in subprocesses and hence the AMR can adapt to these variations without complex reconfigurations and programming. By implementing such a digital platform we shall be able to have a traceability and seamless interoperability of complex systems including AMR. We shall be able to easily reconfigure the system by parameters, and we shall be able to efficiently manage, visualize and analyse data and monitor and optimise features at multiple factory levels.


# Build and install
**Attention:** 
This is not a final version, this is just a first snapshot that connects to AMR-Simulator.
Not everything might work correctly. In addition, there will be adaptions/enhancements for the physical installation.
The final version will be published, when we finished adaptions to the physical installation.


There are two different ways to start the software:
## Option 1:
1. Follow the instructions on [FEATS](https://github.com/Dalma-Systems/FEATS) and setup FEATS. If FEATS is not running, AMRControl will not work.
2. Setup a robot, a warehouse, at least one warehouse, at least one workstation, one idle-station and at least one work order (If this is not done by specific software, it can easily be done by using dalma_feats.postman_collection.json which is provided by feats)
3. Clone the code of AMRControl to a local directory
4. Open it in Visual Studio or any other IDE supporting C#
5. Compile and run
6. Open http://localhost:44310 in a browser of you choice

## Option 2:
As soon as the code is final, we will provide a Docker-image.

# Documentation and workflow
The main intent of AMRControl is to control an AMR that operates in a workshop with numerous milling machines.
The workflow consists of four steps.
1. Select a work-order that was created by ERP within Fiware. This is done by clicking on the first Button called "Choose and start task". This opens a modal window where a task can be chosen. Then the robot moves to the tool dispense and tools can be loaded.   
2. When all tools are loaded click on "Tool dispensing finished". Then the robot will move to the workplace that is assigned to the specific workorder.
3. The movement of the robot to the workplace is show until it arrives at the workplace. Then "AMR arrived" can be clicked and tools can be unloaded.  
4. After all tolls are withdrawed, "Tool withdrawal finished" has to be clicked and the robot moves either to the idle-position or to the tool-dispenser again to fulfill a new workorder.

# License
[Apache](https://github.com/flexmill/AMRControl/blob/main/LICENSE) © 2022 [TCM-Systems](https://tcm-systems.eu/)
