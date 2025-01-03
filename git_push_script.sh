#!/bin/bash

# Prompt for commit message
read -p "Enter commit message: " msg

# Execute git commands
git add .
git commit -m "$msg"
git push
