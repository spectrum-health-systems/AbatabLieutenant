<div align="center">

![AbatabLogo](AbatabLieutenantLogo.png)

Current version: 4.2 (released July 5, 2023)

</div>

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="RepositoryData/Asset/Image/Document/README/spacer.png" alt="blank-spacer" width="1000" height="1">

  ### CONTENTS
  [About](#about)  
  [Getting started](#getting-started)  
  [Using](#using)  
  [Logs](#logs)  
  [Additional information](#additional-information)  

</td>
</tr>
</table>

# About

[Abatab Lieutenant](https://github.com/spectrum-health-systems/AbatabLieutenant) is a deployment manager for Abatab.

**By default, Abatab Lieutenant will only deploy branches to the Abatab instance available to UAT.**

**Deploying branches to the Abatab instance available to LIVE should be done manually.**

# Configuration

Configuration settings for Abatab Lieutenant can be found in the local `AbatabLieutenant.json` file.

There are only two settings that should be modified:

* **AbServiceRoot**  
The root directory where your Abatab installation is located for your organization.  
Keep in mind that this should be the location of Abatab for your *UAT* environment, and *not* production.

* **ValidBranches**  
If you want to deploy a branch that is not "main" or "testing", you can add it to this list.

# Deploying the Abatab testing branch

>By default, Abatab Lieutenant will only deploy branches to the Abatab instance available to UAT.  
>
>Deploying branches to the Abatab instance available to LIVE should be done manually.

## XX. Update Settings.settings

Using Visual Studio:

* Update `AbatabVersion` to the current version
* Update `AbatabBuild` to the current build

### XX. Rebuild Abatab

Using Visual Studio:

* Clean the Abatab solution
* Rebuild the Abatb solution

## XX. Commit to development branch

Using GitHub Desktop (or your prefered Git client/method):

* Commit changes to the current development branch.

## XX. Create a pull request for the testing branch

Using GitHub.com:

* Create a pull request from the development branch to the testing branch
* Merge branches

## XX. Deploy the testing branch to the web server

Login to the web server that hosts Abatab and:

* Open a Command Prompt as Administrator
* Type `cd ../../IT/Abatab Lieutenant`
* Type `AbatabLieutenant`, and a simple help screen should pop up
* Type `AbatabLieutenant testing`

## XX. Update Web.config

Find the `Web.config` file for the Abatab deployment and:

* Verify `LoggerMode` is set to `enabled`
* Verify `LoggerTypes` is set to `all`
* Update `AvatarEnvironment`
* Update `AbatabEmailPassword`
* Verify `DebugglerMode` is set to `disabled`

### Deploying a custom branch

To deploy a custom Abatab branch:

1. Modify the `ValidBranches` entry in the `AbatabLieutenant.json` file to include the custom branch:

```csharp
  "ValidBranches": [
    "main",
    "testing",
    "MyCustomBranch"
  ],
```

# Logging

Abatab Lieutenant will display log information to the console, as well as a log file located in **%LtntRoot%\Logs\\**

# The Abatab Lieutenant process

<div align="center">

  ```mermaid
  graph TD

      AbatabLieutenant.exe([AbatabLieutenant.exe]) --> PassedArgumentCheck{"More than one argument passed <br> AND <br> argument is valid"}
      
      PassedArgumentCheck -- No --> DisplayHelp.cs(Display help <br> to console)
      DisplayHelp.cs --> ExitLtnt([Exit])

      PassedArgumentCheck -- Yes --> InitializeFramework(Initialize <br> Abatab Lieutenant <br>framework)
      InitializeFramework --> BackupCurrent(Backup <br>current deployment)
      BackupCurrent --> PrepareTarget(Prepare <br>deployment target)
      PrepareTarget --> DeployBranch(Deploy <br> requested branch)
      DeployBranch --> ExitLtnt
  ```
</div>

# Deploying an Abatab branch to the instance available to LIVE

By default, deploying Abatab branches to the instance available to LIVE must be done manually. This is by design, and ensures the Abatab instance available to LIVE is not impacted by testing development branches of Abatab.

Deploying an Abatab branch to the instance available to LIVE should be done when users are not in the system. Your options are:

1. Deploy after hours (e.g., 11PM on a Saturday) when users most likely won't be in the system
2. Deploy during Avatar scheduled maintenance
3. Disable all ScriptLink calls from within Avatar (very time consuming, don't do this)

Once you are ready to deploy:

1. Remove all files from `C:\AvatoolWebService\Abatab_LIVE`
2. Copy all files from `C:\AvatoolWebService\Abatab_UAT` to `C:\AvatoolWebService\Abatab_LIVE`
3. Make the necessary configuration setting changes in Web.config

[AbatabLieutenantLogo]: ../../resources/images/logos/AbatabLieutenantLogo.png
