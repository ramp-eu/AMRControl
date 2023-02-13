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

# Design thoughts:
- Server-based Web-interface to allow access from several computers via browser without local installation
- Interface must be as simple as possible
- As this is a proof of concept not all possible errors are cought in the code, the code relies on the entities that are described in the prerequisites

# Build and install

## Option 1:
1. Follow the instructions on [FEATS](https://github.com/Dalma-Systems/FEATS) and setup FEATS. If FEATS is not running, AMRControl will not work. Alternatively use a physical robot-installation from DALMA robotics. CoFFEE from Dalma is not needed.
2. Setup a robot, a warehouse, a toolcenter, at least one workstation, one idle-station and at least one work order (If this is not done by specific software, it can easily be done by using Postman with dalma_feats.postman_collection.json which is provided by feats). In addition you can use the JSONs below
3. Clone the code of AMRControl to a local directory
4. Open it in Visual Studio or any other IDE supporting C#
5. Compile and run
6. A website with the interface pops up. The interface should be self-explanatory

## Option 2:
1. Do the same as above
2. Let Visual Studio create a Docker-image
3. Use the image

# Workflow
The main intent of AMRControl is to control an AMR that operates in a workshop with numerous milling machines.
## Process 1:
The workflow consists of four steps.
1. Select a work-order that was created by ERP within Fiware. This is done by clicking on the first Button called "Choose and start task". This opens a modal window where a task can be chosen. Then the robot moves to the tool dispenser and tools can be loaded.   
2. When all tools are loaded click on "Tool dispensing finished". Then the robot will move to the workstation that is assigned to the specific workorder.
3. The movement of the robot to the workplace is show until it arrives at the workplace. Then "AMR arrived" can be clicked and tools can be unloaded.  
4. After all tolls are withdrawed, "Tool withdrawal finished" has to be clicked and the robot moves either to the idle-position or to the tool-dispenser again to fulfill a new workorder. The current workorder is deleted from Orion.

## Process 2:
1. AMR-Control is constantly checking in the background, if a warning is sent, that one or more tools in the workstation have to be replaced.
2. This warning is shown as a popup with a list of tools to replace. The tools can be sent to the workstation.
3. When the tools are replaced and the warning is confirmed, it is deleted from Orion.

# Json-Data
These JSONs are working examples, you can change them to your needs. All of these JSONs can be added by using Postman and this URL:
{{orion_url}}/v2/entities?options=keyValues
Replace {{orion_url}} with the URL of your Orion-Instance.
The data can be found here: [https://github.com/flexmill/Data-structures](https://github.com/flexmill/Data-structures)


# License
[Apache](https://github.com/flexmill/AMRControl/blob/main/LICENSE) © 2022 [TCM-Systems](https://tcm-systems.eu/)
