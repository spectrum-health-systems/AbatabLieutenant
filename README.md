<div align="center">

  [![Logo][Logo]][MainBranchUrl]

# Command line management utility for Abatab

  ![Status][Status]&nbsp;&nbsp;![License][License]&nbsp;&nbsp;![CurrentRelease][CurrentRelease]

  ***
  ### [Changelog][Changelog]&nbsp;&bull;&nbsp;[Roadmap][Roadmap]&nbsp;&bull;&nbsp;[ManHome][ManHome]&nbsp;&bull;&nbsp;[Sourcecode documentation][SrcDocHome]

  ***

</div>

<br>



***

<div align="center">
  <h2>
    For Spectrum Health Systems use only
  </h2>
</div>

***

<br>

# About

Abatab Lieutenant is a simple utility that deploys branches of Abatab to the server where where Abatab is hosted.

# Using

To use Abatab Lieutenant:

1. Download the latest [release](https://github.com/spectrum-health-systems/AbatabLieutenant/releases)

2. Uncompress the .zip file to the server where Abatab is hosted

3. Verify that the configuration settings in `AbatabLieutenant.exe.config` are correct

4. Run `AbatabLieutenant.exe`

## Default behavior

The default Abatab Lieutenant behavior is to deploy the `testbuild` branch of Abatab to to `C:\Abatab\UAT`.

## Runtime behavior

You can display the help screen, or specify another branch to deploy, at runtime by using the following syntax:

``` bash
AbatabLieutenant.exe <command>
```

For example:

``` bash
AbatabLieutenant.exe help
```

The following are valid Abatab Lieutenant commands:

* `help`  
Abatab Lieutenant help (this screen)

* `development`  
Deploy the Abatab development branch

* `experimental`  
Deploy the Abatab experimental branch

* `main`  
Deploy the Abatab main branch

* `testbuild`  
Deploy the Abatab tesbuild branch (default)

# Configuring

You can also change the default behavior of Abatab Lieutenant by modifying the values in `AbatabLieutenant.exe.config`.

> DebugMode = disabled

Specifies if debugging information will be displayed on the screen when you run Abatab Lieutenant.

DebugMode can either be `enabled` or `disabled`.

> LtntVersion = 2.0

The version of Abatab Lieutenant.

> LtntRoot = C:\Abatab\UAT

The root directory where Abatab will be deployed.

> RepoUrl = https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/

The base URL for the Abatab branches.

> DefaultBranch = testbuild  

The Abatab branch to deploy when typing `AbatabLieutenant.exe`.  This can be one of the following branches:

* `development`

* `main`

* `testbuild`

* `experimental`

# Logging

Abatab Lieutenant logs can be found here:  
`C:\Abatab\UAT\logs\lieutenant\`

<!-- REFERENCE LINKS -->
[AbatabRepoUrl]: https://github.com/spectrum-health-systems/Abatab
[MainBranchUrl]: README.md
[Logo]: /.github/res/img/logo/RepositoryLogo.png
[Status]: https://img.shields.io/badge/Active-brightgreen?style=flat-square
[License]: https://img.shields.io/github/license/spectrum-health-systems/AbatabLieutenant?style=flat-square
[CurrentRelease]: https://img.shields.io/github/v/release/spectrum-health-systems/AbatabLieutenant?style=flat-square
[CurrentReleaseUrl]: https://github.com/spectrum-health-systems/AbatabLieutenant/releases
[Changelog]: /doc/CHANGELOG.md
[Roadmap]: /doc/ROADMAP.md
[ManHome]: /doc/man/ManHome.md
[SrcDocHome]: /doc/srcdoc/SrcDocHome.md
