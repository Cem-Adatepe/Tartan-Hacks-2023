/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Diagnostics;
using System.Threading;
void Start() 
{
    TestShell();
}

[MenuItem("Test/Shell")]
static void TestShell()
{
    var thread = new Thread(TestShellThread);
    thread.Start();
}

static void TestShellThread ()
{
    Process proc = new Process();
    proc.StartInfo.FileName = "/bin/bash";
    proc.StartInfo.WorkingDirectory = Application.dataPath;
    proc.StartInfo.Arguments =  "python3 ../../../../algorand/unityRunner.py";
    proc.StartInfo.CreateNoWindow = false;
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.RedirectStandardInput = true;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
    {
        if (!string.IsNullOrEmpty(e.Data))
        {
            UnityEngine.Debug.Log(e.Data);
        }
    });
    this.proc.StandardInput.WriteLine("makeAccount Alice \n");
    this.proc.StandardInput.WriteLine("makeAccount Bob \n");
    this.proc.StandardInput.WriteLine("makeAccount Carl \n");
    this.proc.StandardInput.WriteLine("makeNft swaz \n");
    this.proc.StandardInput.WriteLine("makeAuction Knight Alice Alice swaz 60 \n");
    this.proc.StandardInput.WriteLine("setupAuction Knight Alice swaz 60 \n");
    this.proc.StandardInput.WriteLine("makeBid Knight Bob 5 \n");
    this.proc.StandardInput.WriteLine("optIn swaz Bob \n");
    this.proc.StandardInput.WriteLine("makeBid Knight Carl 10 \n");
    this.proc.StandardInput.WriteLine("optIn swaz Carl \n");
    this.proc.StandardInput.WriteLine("makeBid Knight Bob 15 \n");
    this.proc.StandardInput.WriteLine("makeBid Knight Carl 20 \n");
    this.proc.StandardInput.WriteLine("closeAuction Knight Alice \n");

    proc.Start();
    proc.BeginOutputReadLine();
    proc.WaitForExit();
    proc.Close();
}
*/