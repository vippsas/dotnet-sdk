# Running tests locally

Have to have a KeyVault with settings as used in TestSetup.cs

Have to package the Vipps.net dependency as is done in build_and_test.yml. E.g.

```bash
paket pack path-to-vipps-net/Vipps.net --version 0.0.0
```