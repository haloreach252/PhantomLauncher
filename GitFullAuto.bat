set /P gitType="Type (Prep, Commit, Check): "
cd h:\Coding\C#Projects\PhantomLauncher
"C:\Program Files\Git\bin\sh.exe" -c ./git%gitType%.bat