# KillScript

This script is  designed to monitor and kill enabled browser processes based on configuration settings.

## Overview

The script reads from a `config.json` file to determine which browser processes should be monitored. If a browser is enabled in this configuration, the script will continuously check for and terminate its processes.

## Prerequisites

Ensure that you have the following prerequisites installed:
- .NET Runtime that matches the project's requirements

## Configuration

The script reads configuration settings from a `config.json` file which should be in the same directory as the executable and structured as follows:

```json
{
  "ApplicationSettings": {
    "ChromeEnabled": true,
    "FirefoxEnabled": true,
    "IEEnabled": false,
    // Add other browsers as needed
  }
}
