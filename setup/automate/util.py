# -*- coding: UTF-8 -*-
import os
import sys
from os.path import join, dirname, isfile
from os import makedirs, remove
from shutil import copy2
from . import log

this = sys.modules[__name__]
this.is_validation_checked = False

__logger = log.get_logger()

def is_windows():
  return os.name == "nt"

def str2bool(v):
  return v.lower() in ("yes", "true", "t", "1")

def check_validation(dir_path):
  if not this.is_validation_checked:
    dotenv_path = join(dir_path, ".env")
    if not isfile(dotenv_path):
      __logger.error(".env file not exists")
      return False

  return True

def copy_file(src_path, dst_path, file_name):
  try:
    makedirs(dst_path)
  except:
    pass

  src_file_path = join(src_path, file_name)
  dst_file_path = join(dst_path, file_name)

  try:
    remove(dst_file_path)
  except:
    pass

  try:
    copy2(src_file_path, dst_file_path)
  except:
    pass
