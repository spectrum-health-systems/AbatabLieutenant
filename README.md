
<div align="center">

![Followers][GitHubFollowers] ![Forks][GitHubForks] ![Stars][GitHubStars] ![Watchers][GitHubWatchers]

[![Logo][Logo]][MainBranchUrl]

## Command line management utility for Abatab

![Status][Status]&nbsp;&nbsp;&nbsp;[![License][License]][LicenseUrl]&nbsp;&nbsp;&nbsp;![.NET][DotNet]&nbsp;&nbsp;&nbsp;![Release][Release]

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

Abatab Lieutenant is a simple utility that deploys branches of [Abatab][AbatabUrl] to the server where where Abatab is hosted.

By default, Abatab Lieutenant is intended to be used with non-production installations of Abatab. It's recommended that you deploy Abatab to your production environments manually.

Please see the [changelog](Changelog) for a history of changes, and the [roadmap](Roadmap) for any upcoming features/fixes.

## A note about the source code

I doubt Abatab Lieutenant will be used outside Abatab development (the better choice would be [Abatab Commander][AbatabCommanderUrl], so I had a little fun with the source code - I definately didn't use best practices. If statements without brackets, short (but still descriptive!) variable names, zero comments, oh my!

## Features

* Cross-platform

* Configurable via local configuration file

# Getting started

## Installing

Abatab Lieutenant is a portable application, so it doesn't need to be installed. All you need to do is:

1. Download the latest [release](ReleaseUrl), then
2. Uncompress the .zip file to a location on the server where Abatab is hosted

# Using

Before you use Abatab Lieutenant, it is recommended that you confirm that the default settings in AbatabLieutenant.exe.config are correct for your organization:

* The location of your Abatab instance for your UAT environment is "**C:\Abatab\UAT**"
* The Abatab branch you will be deploying is "**testbuild**"

If any of the default settings will not work at your organization, please make the required changes to the configuration file.

## Default behavior

To use the Abatab Lieutenant, open a terminal and type `AbatabLieutenant.exe`.

Abatab Lieutenant will then:

1. Download the latest **testbuild** branch of Abatab
2. Deploy the **testbuild** branch to **C:\Abatab\UAT**

## Customizing the deployed branch via the command line

To deploy a specific branch, open a terminal and type `AbatabLieutenant.exe %BranchName%`, where **%BranchName%** is one of the following:

* development
* main
* testbuild
* experimental

For example, to deploy the **main** branch, you would type `AbatabLieutenant.exe main`

## Customizing via the configuration file

You can also change the default behavior of Abatab Lieutenant by modifying the values in **AbatabLieutenant.exe.config**.

### DebugMode

> Default: **disabled**

IF this is set to **enabled**, debugging information will be displayed on the screen when you run Abatab Lieutenant.

### LtntVersion

> Default: **2.0**

The version of Abatab Lieutenant. This should not be changed.

### LtntRoot

> Default: **C:\Abatab\UAT**

This root directory where Abatab Lieutenant will be deploy the specified Abatab branch.

### RepoUrl

> Default: **https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/**

The base URL for the Abatab branches. This should not be changed.

### DefaultBranch

> Default: **testbuild**

The Abatab branch to deploy, which can be one of the following:

* development
* main
* testbuild
* experimental

## Help

To display the Abatab Lieutenant help information, type `AbatabLieutenant.exe help`

# Logs

Abatab Lieutenant logs can be found here in **%LtntRoot%\logs\lieutenant\\**, so by default that would be **C:\Abatab\UAT\logs\lieutenant\\**

## Debug logs

When **DebugMode = enabled**, debug information will be written to the console at the start of the log file.

Debug information is not written to log files.

# Additional information

Abatab Lieutenant is developed by [A Pretty Cool Program](APrettyCoolProgramUrl).

***



<!-- REFERENCE LINKS -->

[GitHubFollowers]: https://img.shields.io/github/followers/spectrum-health-systems?style=social
[GitHubForks]: https://img.shields.io/github/forks/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubStars]: https://img.shields.io/github/stars/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubWatchers]: https://img.shields.io/github/watchers/spectrum-health-systems/AbatabLieutenant?style=social
[DotNet]: https://img.shields.io/badge/.NET-6.0-blueviolet

[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[MainBranchUrl]: README.md
[Logo]: /.github/res/img/logo/RepositoryLogo.png
[Status]: https://img.shields.io/badge/status-active-brightgreen?style=flat
[License]: https://img.shields.io/badge/license-apache%202.0-brightgreen?style=flat
[LicenseUrl]: https://www.apache.org/licenses/LICENSE-2.0
[Release]: https://img.shields.io/github/v/release/spectrum-health-systems/AbatabLieutenant?style=flat
[ReleaseUrl]: https://github.com/spectrum-health-systems/AbatabLieutenant/releases

[AbatabCommanderUrl]: https://github.com/spectrum-health-systems/AbatabCommander
[Changelog]: /docs/CHANGELOG.md
[Roadmap]: /docs/ROADMAP.md
[APrettyCoolProgramUrl]: https://github.com/APrettyCoolProgram


![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/spectrum-health-systems/AbatabLieutenant)
![Lines of code](https://img.shields.io/tokei/lines/github/spectrum-health-systems/AbatabLieutenant)
![GitHub repo file count](https://img.shields.io/github/directory-file-count/spectrum-health-systems/AbatabLieutenant)
![GitHub repo size](https://img.shields.io/github/repo-size/spectrum-health-systems/AbatabLieutenant)
![GitHub all releases](https://img.shields.io/github/downloads/spectrum-health-systems/AbatabLieutenant/total)
![GitHub issues](https://img.shields.io/github/issues/spectrum-health-systems/AbatabLieutenant)
![GitHub pull requests](https://img.shields.io/github/issues-pr/spectrum-health-systems/AbatabLieutenant)
![GitHub](https://img.shields.io/github/license/spectrum-health-systems/AbatabLieutenant)

![GitHub last commit](https://img.shields.io/github/last-commit/spectrum-health-systems/AbatabLieutenant)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/spectrum-health-systems/AbatabLieutenant/development)



























