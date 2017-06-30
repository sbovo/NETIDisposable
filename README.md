# NETIDisposable
Explore and understand IDisposable in .NET

## Purpose of the IDisposableInAction project
Working on the implementations of IDisposable is not so easy. The IDisposableInAction project would be able to help you understanding how the Garbage Collector release memory.

## Testing the IDisposableInAction project
In the program.cs, you have 3 code blocks: One for each test. You can uncomment one of these block and run the RELEASE compiled version of the console app.
The app wait for you to press ENTER. It is time for you to take a memory dump (instructions below).
You can then press ENTER and before the app finishes, you can take another dump.
!![consoleAppWaitingForENTER](https://user-images.githubusercontent.com/10991852/27739828-3b354daa-5db0-11e7-89cb-9c460de46bc8.png)

You be then able to look at the taken dumps for each scenarios in order to figure out what are the objects still in the process memory.

### Creating a dump
For taking a dump, you can just use ProcDump.exe from SysInternals Suite:
![CreateADumpWithProcdump](https://user-images.githubusercontent.com/10991852/27739097-bdb0d6b2-5dad-11e7-89ec-504e4f70cbe0.png)

### Quick look with WinDbg
You can then freely open the dumps with WinDbg. The initial steps are:
1. Set the Symbols path
`.sympath SRV*C:\_PublicSymbols*http://msdl.microsoft.com/download/symbols

2. Load the symbols
`.reload

3. Load SOS extension
`.loadby sos clr

![InitialStepsWithWindbg](https://user-images.githubusercontent.com/10991852/27740779-56b56760-5db3-11e7-86f0-75fbc044b158.png)

4. Count your object still in memory
`!DumpHeap -stat
![DumpHeap](https://user-images.githubusercontent.com/10991852/27740871-9d4c2baa-5db3-11e7-99d9-35f863db5aa0.png)
