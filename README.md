# Crucible Hook

The glue you need to join GitLab and Crucible together.

## Overview

This project provides WebAPI endpoints allow GitLab to use web hooks to communicate with Crucible.

## Why a custom solution?

The [web hooks](https://gitlab.com/gitlab-org/gitlab-ce/blob/master/doc/web_hooks/web_hooks.md) (post-commit hooks) made available by GitLab only allow specifying a URL for HTTP operations.

Crucible's support for [commit hooks](https://confluence.atlassian.com/display/FISHEYE/Configuring+commit+hooks) requires a specifically formatted POST operations (with custom headers).

In order to join the two together, a custom tool is required to expose an endpoint can properly construct a POST request to Crucible.

## How it works

Crucible Hook provides an endpoint that will take a POST from GitLab and form a new POST request to Crucible adding the REST API key.

## Deployment and setup

* Deploy the WebAPI project to a web server with IIS installed
	* Requires ASP.NET 4.5
* Add environment-specific values to Web.config
	* Open the [Web.config](CrucibleHook/CrucibleHook/Web.config) file in the root of the application
	* Set `CrucibleBaseUrl` to the URL of the Crucible server (ex. `http://crucible.example.com`)
	* Set `ApiKey` to the [REST API token](https://confluence.atlassian.com/display/FISHEYE/Setting+the+REST+API+token) configured for Crucible
* Add a web hook in GitLab
	* Go to the repository settings in GitLab
	* Add a new web hook
	* Point the URL at the `/api/crucible/<NAME_OF_CRUCIBLE_REPOSITORY>` location (ex. `http://webserver.example.com/CrucibleHook/api/crucible/example-repository`)
