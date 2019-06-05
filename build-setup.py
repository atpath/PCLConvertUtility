# -*- coding: UTF-8 -*-
from os.path import join, dirname
from os import mkdir
import datetime
from dotenv import load_dotenv
from setup.automate.log import get_logger, execute_and_log, set_logger
from setup.automate.build import build_installer
from setup.automate.util import check_validation

if __name__ == "__main__":

  dir_path = dirname(__file__)

  output_path = join(dir_path, "Output", datetime.datetime.now().strftime("%Y%m%d-%H%M%S"))
  mkdir(output_path)

  set_logger(output_path)

  if not check_validation(dir_path):
    exit()

  # Load settings from .env file into environ
  dotenv_path = join(dir_path, ".env")
  load_dotenv(dotenv_path)

  build_installer(output_path)
