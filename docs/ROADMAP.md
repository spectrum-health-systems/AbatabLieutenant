# Abatab Roadmap

## 22.11.0 (November 2022)

### Abatab

#### Abatab.Abatab.asmx.cs

* No changes

#### Abatab.Roundhouse.cs

#### Abatab.WebConfig.cs

### Core functionality

* [ ] Test to make sure that replacing DLL files works as expected

#### AbatabData

* No changes

#### AbatabLogging

* [ ] Test all log types to make sure they are written to the correct folder
* [ ] Test debugMode to make sure that "on" -> "enabled" is working correctly
* [ ] Fix access log filename/contents

#### AbatabOptionObject

* No changes

#### AbatabSession

* No changes

#### AbatabSystem

* No changes

### Abatab Modules

#### ModCommon

* No changes

#### ModProgressNote

* [ ] Test ProgressNote.??
* [ ] Verify valid user settings

#### ModPrototype

* No changes

#### ModQuickMedOrder

* [ ] Test Dose.VerifyUnderMaxPercentIncrease
* [ ] Test Dose.VerifyUnderMaxMilligramIncrease
* [ ] Verify valid user settings

#### ModTesting

* No changes

### Documentation

* [ ] Details soon

***

## 22.11.1 (November 2022)

### Core functionality

* [ ] Code/comment refactor

#### AbatabData

* No changes

#### AbatabLogging

* No changes

#### AbatabOptionObject

* No changes

#### AbatabSession

* No changes

#### AbatabSystem

* No changes

### Abatab Modules

#### ModCommon

* No changes

#### ModProgressNote

* No changes

#### ModPrototype

* No changes

#### ModQuickMedOrder

* [ ] Cleanup/refactor Dose.VerifyUnderMaxPercentIncrease
* [ ] Cleanup/refactor Dose.VerifyUnderMaxPercentIncrease

#### ModTesting

* No changes

### Documentation

* [ ] Cleanup DocFX folders
* [ ] Complete all XML documentation

***

## 22.12.0 (December 2022)

### Core functionality

* [ ] Cleanup project references
* [ ] Verify Settings.settings order matches objects (including WebConfig.cs)
* [ ] Cleanup public/private/internal
* [ ] Add the Abatab version to related log files
* [ ] Verify that the AbatabOption doesn't get in the way of anything
* [ ] Experiment with <10ms log file delay
* [ ] Better method names so user knows what/where things point from other projects. ex. AbatabOptionObject.FinalObj.Finalize(abatabSession) should be something like "FinalOptObj.Finalize", so we can declare the project in the usings section

#### AbatabData

* No changes

#### AbatabLogging

* [ ] Verify "none" works
* [ ] Veriry all combinations of log events work
* [ ] Logging detail level (e.g., "TRACE-01", "TRACE-02")
* [ ] Error logs
* [ ] Warning logs
* [ ] Lost logs

#### AbatabOptionObject

* No changes

#### AbatabSession

* No changes

#### AbatabSystem

* No changes

### Abatab Modules

* [ ] Separate the main looping somewhere else.

#### ModCommon

* No changes

#### ModProgressNote

* No changes

#### ModPrototype

* No changes

#### ModQuickMedOrder

* [ ] Test Dose.VerifyUnderMaxPercentDecrease
* [ ] Test Dose.VerifyUnderMaxMilligramDecrease

#### ModTesting

* No changes

### Documentation

* No changes

## 22.11.1


***
***

> Template

***

## YY.MM.xx (%Month% %Year%)

### Core functionality

#### AbatabData

* No changes

#### AbatabLogging

* No changes

#### AbatabOptionObject

* No changes

#### AbatabSession

* No changes

#### AbatabSystem

* No changes

### Abatab Modules

#### ModCommon

* No changes

#### ModProgressNote

* No changes

#### ModPrototype

* No changes

#### ModQuickMedOrder

* No changes

#### ModTesting

* No changes

### Documentation

* No changes
