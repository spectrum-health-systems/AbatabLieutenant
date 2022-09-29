***

<div align="center">
  <h2>
    For Spectrum Health Systems use only
  </h2>
</div>

***

<br>

# About

Abatab Lieutenant is a *very* simple utility that deploys the development branch of Abatab to Abatab_UAT/ on the IIS server where Abatab is hosted.

I needed something to streamline the deployment while developing Abatab, and I needed it quick. So this code isn't particularly well written or organized.

In addition, I don't think there will need to be any updates/modifications, so v1.0.0 will be the first version, and the last.

## Logging

If you run into problems, the Abatab Lieutenant logs can be found here:  
`C:\AvatoolWebService\Abatab_UAT\Logs\AbatabLieutenant`

If logging stops working, delete this folder:  
`C:\AvatoolWebService\Abatab_UAT\logs\lieutenant\`

# Using

## Before you do anything

* Make sure that the Abatab development branch is located here:  
`https://github.com/spectrum-health-systems/AbatabLieutenant/tree/development`

* Make sure that the deployment location on the IIS server is located here:  
`C:\AvatoolWebService\Abatab_UAT\`

* If this is your first time running Abatab Lieutenant, make sure the following directory *does not* exist:  
`C:\AvatoolWebService\Abatab_UAT\logs\lieutenant\`

## Running Abatab Lieutenant

Run `AbatabLieutenant.exe`

That's, uh, it.
