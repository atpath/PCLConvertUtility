# -*- coding: UTF-8 -*-
import logging
from os.path import join, dirname
from os import makedirs
from datetime import datetime
import subprocess

def set_logger(log_path):

  log_file = join(log_path, "setup.log".format(datetime.now()))

  log = logging.getLogger("setup")
  log.setLevel(logging.INFO)

  # create formatter and add it to the handlers
  formatter = logging.Formatter("%(asctime)s:%(module)s:%(funcName)s:%(levelname)s: %(message)s")

  # create file handler which logs even debug messages
  fh = logging.FileHandler(log_file, 'w', 'utf-16')
  fh.setLevel(logging.DEBUG)
  fh.setFormatter(formatter)
  log.addHandler(fh)

  # create console handler with a higher log level
  ch = logging.StreamHandler()
  ch.setLevel(logging.INFO)
  ch.setFormatter(formatter)
  log.addHandler(ch)

def get_logger():
  return logging.getLogger("setup")

logger = get_logger()

def execute_and_log(cmd):
  logger.info("execute command: %s", " ".join(cmd))
  p = subprocess.Popen(" ".join(cmd), stdout=subprocess.PIPE, stderr=subprocess.PIPE, universal_newlines=True)
  stdout, stderr = p.communicate()

  if stdout:
    logger.info(stdout)
  if stderr:
    logger.error(stderr)
