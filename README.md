# Secrets of DotNet10

## NOTICE: Technical Fork

This fork is a technical fork of https://github.com/Secrets-of-Sosaria/World
Release: Humility, Dec 20, 2025, which was latest as of 6/27/2026.

The purpose of this fork is to establish a clean foundation on the .NET 10 framework. For your convenience, a migration HowTo-document has been added.

Other than noted below, only modifications strictly related to .NET 10 conversion were made.

### Target Audience

Implementers. Please excuse not making a proper pull request; I'm not super familiar with github, and I want this port to stand on its own.
As this is a technical fork, I have not altered any project files, most prominently the original server name "Secrets of Sosaria", as I wanted to change only the minimum of files. If
you download/fork this repo, please honor the condition mentioned in the manual to give your project a different name than the parent project. If you are a SoS maintainer: I'm trying to save you some work. Should you be unhappy regardless, let me know how specifically to make you less unhappy. Your civility and consideration will be appreciated and reciprocated.

### Other Additions

- World Load: mobiles causing exceptions are logged and discarded, instead of terminating the app. We rely on the world spawn to re-populate mobiles, but if no load errors occur, the modification should be transparent.
- Server maintains and displays independent build number on startup




