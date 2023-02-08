<div align="center">

![Followers][GitHubFollowers] ![Forks][GitHubForks] ![Stars][GitHubStars] ![Watchers][GitHubWatchers]

[![Logo][Logo]][MainBranchUrl]

## Abatab deployment utility

![Status][Status]&nbsp;&nbsp;&nbsp;[![License][License]][LicenseUrl]&nbsp;&nbsp;&nbsp;![.NET][DotNet]&nbsp;&nbsp;&nbsp;![Release][Release]&nbsp;&nbsp;&nbsp;![Issues][Issues]&nbsp;&nbsp;&nbsp;![PullRequests][PullRequests]

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

Abatab Lieutenant is a simple utility that deploys development branches of [Abatab][AbatabUrl] to the server where where Abatab is hosted.

By default, Abatab Lieutenant will deploy the **testing** branch of Abatab to your testing/UAT environment.

Abatab Lieutenant is intended to be used with non-production installations of Abatab.

***It is recommended that you deploy Abatab to your production/LIVE environments manually.***

Please see the [changelog][Changelog] for a history of changes, and the [roadmap][Roadmap] for any upcoming features/fixes.

## Features

* Cross-platform
* Configurable via local configuration file

# Getting started

## Installing

Abatab Lieutenant is a portable application, so it doesn't need to be installed. All you need to do is:

1. Download the latest [release][ReleaseUrl], then...
2. Uncompress the .zip file to a location on the server where Abatab is hosted

# Configuration

Before you use Abatab Lieutenant, it is recommended that you confirm that the default settings in **AbatabLieutenant.exe.config** are correct for your organization.

The default configuration is:

| Setting           | Description                                                                                | Default |
| ----------------- | ------------------------------------------------------------------------------------------ | ------- |
| **LtntVersion**   | The current version of Abatab Lieutenant. | `3.0.0` |
| **RepositoryUrl** | The base Abatab repository URL that is used to download branches. | [Link][AbatabBaseUrl] |
|


**LtnVersion
> Default: `3.0.0`  
The current version of Abatab Lieutenant.
<br>
* LtnRoot: `C:\AbatabData\Lieutenant`  
The directory where all Abatab Lieutenant related data will be kept, including:
  * Abatab Lieutenant logs
  * Abatab branch downloads
  * Deployment staging data  
<br>
* RepositoryUrl: `https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/`  
The Abatab repository base URL.

* CustomBranch: `<empty>`  
You can specify a *custom branch* that is not included in the default branches.

* AbatabDeploymentRoot: `C:\Abatab\UAT`  
The location where you want to Abatab Lieutenant to deploy an Abatab branch.

If any of the default settings will not work at your organization, please make the required changes to the configuration file.

# Using

## Default behavior

Typing `AbatabLieutenant.exe` will display the help information


To use the Abatab Lieutenant, open a terminal and type `AbatabLieutenant.exe %BranchName%`.

For example: `> AbatabLieutenant.exe testing`

Abatab Lieutenant will then:

1. Download the latest **testing** branch of Abatab
2. Deploy the **testing** branch to **C:\Abatab\UAT**

## Customizing the deployed branch via the command line

To deploy a specific branch, open a terminal and type `AbatabLieutenant.exe %BranchName%`, where **%BranchName%** is one of the following:

* development
* main
* testing
* experimental

For example, to deploy the **main** branch, you would type `AbatabLieutenant.exe main`

## Getting help

To display the Abatab Lieutenant help information, type `AbatabLieutenant.exe`

# Logs

Abatab Lieutenant logs can be found here in **%LtntRoot%\lieutenant\logs\\**.

## Debug logs

When **DebugMode = enabled**, debug information will be written to the console at the start of the log file.

Debug information is not written to log files.

# Additional information

Abatab Lieutenant is developed by [A Pretty Cool Program][APrettyCoolProgramUrl].

***

<br>

<div align="center">

  ![LastCommit][LastCommit]&nbsp;&nbsp;&nbsp;![CodeSize][CodeSize]&nbsp;&nbsp;&nbsp;![LinesOfCode][LinesOfCode]&nbsp;&nbsp;&nbsp;![RepoFileCount][RepoFileCount]&nbsp;&nbsp;&nbsp;![RepoSize][RepoSize]

</div>

<!-- Top row -->
[GitHubFollowers]: https://img.shields.io/github/followers/spectrum-health-systems?style=social
[GitHubForks]: https://img.shields.io/github/forks/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubStars]: https://img.shields.io/github/stars/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubWatchers]: https://img.shields.io/github/watchers/spectrum-health-systems/AbatabLieutenant?style=social
[DotNet]: https://img.shields.io/badge/.NET-6.0-blueviolet

[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[MainBranchUrl]: README.md
[Logo]: ./resources/images/logos/AbatabLieutenantLogo.png
[Status]: https://img.shields.io/badge/status-active-brightgreen?style=flat
[License]: https://img.shields.io/badge/license-apache%202.0-brightgreen?style=flat
[LicenseUrl]: https://www.apache.org/licenses/LICENSE-2.0
[Release]: https://img.shields.io/github/v/release/spectrum-health-systems/AbatabLieutenant?style=flat
[ReleaseUrl]: https://github.com/spectrum-health-systems/AbatabLieutenant/releases

[AbatabCommanderUrl]: https://github.com/spectrum-health-systems/AbatabCommander
[Changelog]: https://github.com/spectrum-health-systems/AbatabLieutenant/blob/main/docs/CHANGELOG.md
[Roadmap]: https://github.com/spectrum-health-systems/AbatabLieutenant/blob/main/docs/ROADMAP.md
[APrettyCoolProgramUrl]: https://github.com/APrettyCoolProgram

[AbatabBaseUrl]: https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/

[CodeSize]: https://img.shields.io/github/languages/code-size/spectrum-health-systems/AbatabLieutenant
[LinesOfCode]: https://img.shields.io/tokei/lines/github/spectrum-health-systems/AbatabLieutenant
[RepoFileCount]: https://img.shields.io/github/directory-file-count/spectrum-health-systems/AbatabLieutenant
[RepoSize]: https://img.shields.io/github/repo-size/spectrum-health-systems/AbatabLieutenant
[AllReleases]: https://img.shields.io/github/downloads/spectrum-health-systems/AbatabLieutenant/total
[Issues]: https://img.shields.io/github/issues/spectrum-health-systems/AbatabLieutenant
[PullRequests]: https://img.shields.io/github/issues-pr/spectrum-health-systems/AbatabLieutenant
[LastCommit]: https://img.shields.io/github/last-commit/spectrum-health-systems/AbatabLieutenant
