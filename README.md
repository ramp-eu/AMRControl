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
1. Follow the instructions on [FEATS](https://github.com/Dalma-Systems/FEATS) and setup FEATS. If FEATS is not running, AMRControl will not work. Alternatively use a physical robot-installation from DALMA robotics.
2. Setup a robot, a warehouse, at least one warehouse, at least one workstation, one idle-station and at least one work order (If this is not done by specific software, it can easily be done by using Postman with dalma_feats.postman_collection.json which is provided by feats). In addition you can use the JSONs below
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

Add a robot:
```yaml
{
    "version": "1.2",
    "name": "FlexMill robot",
    "status": "idle",
    "battery": "80",
    "macAddress": "cc4b73b20a20",
    "id": "urn:ngsi-ld:AMR:cc4b73b20a20",
    "refDestination": "urn:ngsi-ld:Idlestation:01",
    "type": "AMR"
}
```

Add Toolcenter:
```json
{
"location": {
  "type": "Point",
  "coordinates": [7.5328, -1.2],
    "metadata": {
       "angle": 1.58021
    }
 },
    "name": "Toolcenter",
    "status": "ready",
    "id": "urn:ngsi-ld:Warehouse:01",
    "type": "Warehouse"
}
```

Add Workstation 1:
{{orion_url}}/v2/entities?options=keyValues
{
"location": {
  "type": "Point",
  "coordinates": [30.8749, 27.4959],
    "metadata": {
       "angle": 1.57418 
    }
 },
    "name": "1065",
    "status": "ready",
    "id": "urn:ngsi-ld:Workstation:1065",
    "type": "Workstation"
}

Add Workstation 2:
{{orion_url}}/v2/entities?options=keyValues
{
"location": {
  "type": "Point",
  "coordinates": [11.4510, 31.9264],
    "metadata": {
       "angle": -0.0868751 
    }
 },
 "name": "1044",
 "status": "ready",
 "id": "urn:ngsi-ld:Workstation:1044",
 "type": "Workstation"
}

Optional: Add additional workstations if needed

Add idle station, the robot is charged and parked here
{
"location": {
  "type": "Point",
  "coordinates": [-1.4216, -0.9897],
  "metadata": {
     "angle": 1.598769    
  }
},
 "name": "Idlestation",
 "status": "ready",
 "id": "urn:ngsi-ld:Idlestation:01",
 "type": "Idlestation"  
}

Add one or more Workorders
The entries in tools and components are shown to the user in the interface. These parts have to be placed on the robot
{
	"status": "scheduled",
	"scheduledAt": "04/10/2022 08:19:30",
	"warehouseId": "urn:ngsi-ld:Warehouse:01",
	"workstationId": "urn:ngsi-ld:Workstation:1044",
	"materials": [
		{
			"tools": [
				{
					"id": "2000268",
					"turret": " 2",
					"station": " 1",
					"orientation": " 1"
				},
				{
					"id": "2000269",
					"turret": " 1",
					"station": " 6",
					"orientation": " 2"
				},
				{
					"id": "2000280",
					"turret": " 2",
					"station": " 5",
					"orientation": " 1"
				},
				{
					"id": "2001287",
					"turret": " 2",
					"station": " 6",
					"orientation": " 1"
				},
				{
					"id": "2001287",
					"turret": " 3",
					"station": " 4",
					"orientation": " 2"
				},
				{
					"id": "2003290",
					"turret": " 2",
					"station": " 4",
					"orientation": " 1"
				}
			]
		},
		{
			"components": [
				{
					"id": "1200446 "
				},
				{
					"id": "1200484 "
				},
				{
					"id": "1200486 "
				}
			]
		}
	],
	"id": "urn:ngsi-ld:WorkOrder:1",
	"dateCreated": "04/10/2022 08:19:30",
	"type": "WorkOrder"
}

Tool-life-cycle:
[
    {
        "id": "102630_ToolLife",
        "type": "Tool_life",
        "102630": {
            "type": "1065",
            "value": [
                {
                    "id": "2000037",
                    "2000037": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "30"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "3"
                        }
                    }
                },
                {
                    "id": "2000039",
                    "2000039": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "250"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "204"
                        }
                    }
                },
                {
                    "id": "2000013",
                    "2000013": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "250"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "102"
                        }
                    }
                },
                {
                    "id": "2003328_SR",
                    "2003328_SR": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "350"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "155"
                        }
                    }
                },
                {
                    "id": "2003328_SL",
                    "2003328_SL": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "500"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "363"
                        }
                    }
                },
                {
                    "id": "2000511",
                    "2000511": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "320"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "302"
                        }
                    }
                },
                {
                    "id": "2000705",
                    "2000705": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "570"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "526"
                        }
                    }
                },
                {
                    "id": "2001180",
                    "2001180": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "400"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "338"
                        }
                    }
                },
                {
                    "id": "2000328",
                    "2000328": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "400"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "20"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "93"
                        }
                    }
                },
                {
                    "id": "2000052",
                    "2000052": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "150"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "21"
                        }
                    }
                }
            ],
            "metadata": {}
        }
    },
    {
        "id": "101177_ToolLife",
        "type": "Tool_life",
        "101177": {
            "type": "1045",
            "value": [
                {
                    "id": "2000037",
                    "2000037": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "20"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "5"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "13"
                        }
                    }
                },
                {
                    "id": "2000039",
                    "2000039": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "150"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "10"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "88"
                        }
                    }
                },
                {
                    "id": "2000511",
                    "2000511": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "30"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "10"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "23"
                        }
                    }
                },
                {
                    "id": "2000011",
                    "2000011": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "300"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "10"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "244"
                        }
                    }
                },
                {
                    "id": "2000007",
                    "2000007": {
                        "monitoringtype": {
                            "type": "Int",
                            "value": "2"
                        },
                        "targetquantity": {
                            "type": "Int",
                            "value": "250"
                        },
                        "warninglimit": {
                            "type": "Int",
                            "value": "10"
                        },
                        "actualquantity": {
                            "type": "Int",
                            "value": "213"
                        }
                    }
                }
            ],
            "metadata": {}
        }
    }
]

# License
[Apache](https://github.com/flexmill/AMRControl/blob/main/LICENSE) © 2022 [TCM-Systems](https://tcm-systems.eu/)
