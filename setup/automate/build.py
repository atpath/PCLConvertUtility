# -*- coding: UTF-8 -*-

from os.path import join, normpath, isfile, isdir
from os import remove, environ, listdir, mkdir
from shutil import rmtree, copytree, copy2
import datetime
from .log import get_logger, execute_and_log

__logger = get_logger()
__output_path = ''
__setup_path = ''
__solution_path = ''
__inno_setup_path = ''
__msbuild_path = ''

def remove_file(file_path):
  try:
    __logger.info("remove file: " + file_path)
    remove(file_path)
  except:
    pass

# Remove all files and subfolders in folder_path,
# But keep the .gitkeep file for version control
def remove_context(folder_path):
  __logger.info("remove context in folder: " + folder_path)
  for the_file in listdir(folder_path):
    file_path = join(folder_path, the_file)
    try:
      if isfile(file_path) and the_file != ".gitkeep":
        remove(file_path)
      elif isdir(file_path):
        rmtree(file_path)
    except:
      pass

def copy_context(src, dst):
  __logger.info(f"Copy context from {src} to {dst}")
  for the_file in listdir(src):
    file_path = join(src, the_file)
    src_path = join(src, the_file)
    dst_path = join(dst, the_file)
    try:
      if isfile(file_path):
        copy2(src_path, dst_path)
      elif isdir(file_path):
        copytree(src_path, dst_path)
    except:
      pass

def clean_up_vs_projects_files():
  __logger.info("clean visual studio generated files")
  solution_file = join(__solution_path, "PCLConvertUtility.sln")
  execute_and_log([__msbuild_path, solution_file, "/t:clean /m:4 /p:Configuration=Release"])

def build_vs_projects():
  __logger.info("Re-build visual studio projects");

  solution_file = join(__solution_path, "PCLConvertUtility.sln")

  pre_parameters = "/m:4 " + \
    "/p:Configuration=Release " + \
    "/p:BuildProjectReferences=true "

  # build ISD.Bridge
  parameters = pre_parameters + \
    "/t:rebuild"
  execute_and_log([__msbuild_path, solution_file, parameters])

def copy_build_files_to_setup_publish_folder():
  __logger.info("Delete publish folder files first")

  delete_file_path = join(__setup_path, "publish")
  remove_context(delete_file_path)

  __logger.info("Copy compiled files to Publish folders")

  src = join(__solution_path, "PCLConvert", "bin", "Release")
  dst = join(__setup_path, "Publish")
  copy_context(src, dst)

def compile_inno_setup_installer(output_path):
  __logger.info("Compile inno setup installer files")

  iss_file_path = join(__setup_path, "PCLConvertUtility.iss")

  __logger.info("Compile Standard Edition installer")
  parameters = '/O"' + output_path +  '"'
  execute_and_log([__inno_setup_path, iss_file_path, parameters])

  __logger.info(f"Generated setup files at: {output_path}")


def build_installer(output_path):
  __logger.info("Start to build installer")

  global __output_path, __setup_path, __solution_path, __inno_setup_path, __msbuild_path

  __output_path = output_path
  __setup_path = normpath(environ["SETUP_PROJECT_PATH"])
  __solution_path = normpath(environ["SOLUTION_PATH"])
  __inno_setup_path = normpath(environ["INNO_SETUP_PATH"])
  __msbuild_path = normpath(environ["MSBUILD_PATH"])

  clean_up_vs_projects_files()
  build_vs_projects()
  copy_build_files_to_setup_publish_folder()
  compile_inno_setup_installer(output_path)
