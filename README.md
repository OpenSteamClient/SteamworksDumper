# SteamworksDumper
A library to dump 32-bit steam for linux `steamclient.so` binary, and retrieve the following information:
- Interface definitions (VTables)
- Function names
- IPC data (interfaceid, functionid, fencepost)
- Function arguments and returns

TODO: 
- Count argc
- Save adapters?
- Dump callbacks
- Dump enums


## Requirements
Capstone installed on your system. 
Only Arch Linux X86_64 has been tested as host OS. Your results may vary.

## Correct binary
The correct binary is `ubuntu12_32/steamclient.so`. A full path would be something like `/home/user/.steam/steam/ubuntu12_32/steamclient.so`
