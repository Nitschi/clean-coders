#!/usr/bin/env bash

set -e

mkdir -p /home/${USER}/.ssh
authorized_key_path=/home/${USER}/.ssh/authorized_keys
if [ ! -z "$SSH_PUBLIC_KEY" ] && [ ! -f ${authorized_key_path} ]; then
  echo $SSH_PUBLIC_KEY >> ${authorized_key_path}
fi
echo $SSH_PUBLIC_KEY
sudo /usr/sbin/sshd -p 4200
