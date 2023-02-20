# Checklist++

It functioned as a utility, designed for the work environment (servers) of the given company.

The task was to check the company's many critically important servers with our own eyes to make sure that everything was working correctly. Thus, we accessed windows servers via rdp, linux via ssh, and devices with web access via a browser. We then run different tests on each server/device according to its scope of work. After the inspection, we documented and saved what we experienced with screenshots.

A completely manual verification process took about 1.5-2 hours, but with this utility we managed to reduce that time to about 20 minutes.

Functions:

- it was able to create a specific folder and file structure within them into a network working directory

- it was able to initiate a bulk remote desktop connection with .rdp files stored in a specified folder

- it was able to find out from the registry whether the external program paint.net is installed on the given client machine (with which the prtscr images were saved) and if so, to determine its startup path and start paint.net together with the Checklist++ program too. It also paid attention to the fact that if paint.net is already open, a warning window should inform the user to save everything in it, and then to close the previous paint.net process and start a new one (this was necessary, among other things, with the appropriate due to canvas size).

- it was able to monitor and mark (green in the list) those servers that we have already checked. When starting the Checklist++ program, the program detected this from the metadata of the folder and file structure created on the network, if the file belonging to the given task is no longer 0KB, then it is done.

- two of us used the program at the same time, and since the program worked from a network, we could also see where the other was, which servers he had already checked, since the corresponding items in the list were green for both of us

![mukodes_kozben2](https://user-images.githubusercontent.com/17532282/194511522-eeab4f5d-ef6a-4d4a-8ca5-5db36ea5acb5.png)

After the basic functions were already provided by the program, extra functions were added later:

-voice control, it was possible to start, for example, the first ten items, or only those that are not ready, etc. (we never actually used it, I wrote it purely out of professional curiosity and development, but it worked)

-for the voice command, the program indicated with different soundpacks if it accepted the command, e.g. in the voice of warcraft peons "work-work", "zug-zug" etc. :-)

-later, there was also a need to specify to the program on which display the rdp windows are loaded by default in a multi-monitor system, this function did not take a final form in the end, due to the shortcomings of win10's window management

![mukodes_kozben3](https://user-images.githubusercontent.com/17532282/194525133-0a33df0a-9058-41dd-b599-12a5d5abe95e.png)
