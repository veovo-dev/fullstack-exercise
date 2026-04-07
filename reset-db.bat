@echo off
echo Deleting flights database files...
del /q "%~dp0backend\DataProducerService\flights.db" 2>nul
del /q "%~dp0backend\DataProducerService\flights.db-shm" 2>nul
del /q "%~dp0backend\DataProducerService\flights.db-wal" 2>nul
echo Done. Run DataProducerService to recreate the database.
