git pull
set /P message="Commit message: "
git add *
git commit -m "%message%"
git push -u origin master