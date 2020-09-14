using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Dialog;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
using System.Timers;
using System.Threading;

namespace Rosita
{

    public class Speech
    {
        public static async Task TalkingAsync(string phrase)
        {
            int notInSwitch = 0;
            string greeting;
            switch (phrase.ToLower())
            {
                case ("hello."):
                case ("hi."):
                case ("hey."):
                case ("hey rosita."):
                case ("rosita."):
                case ("hello rosita."):
                    greeting = "Hello how are you doing?";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case ("how are you rosita."):
                case ("how are you."):
                    greeting = "Im good...thanks for asking.";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case ("i love you rosita."):
                case ("i love you."):
                    greeting = "Calm down there..buddy...You're not my type.";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case ("thank you rosita."):
                case ("thank you."):
                case ("thanks."):
                    greeting = "No problem";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case ("goodbye."):
                case ("bye."):
                case ("see you later."):
                    greeting = "Ok, Goodbye";
                    SynthesizeAudioAsync(greeting).Wait();
                    Program.Exit = 1;
                    break;
                case ("what is today's date?"):
                case ("what's today's date?"):
                case ("what time is it?"):
                case ("what's the time?"):
                case ("what is today?"):
                case ("what is the date?"):
                    greeting = $"Today's date is {DateTime.Now}.";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case ("outlook."):
                case ("open outlook."):
                case ("email."):
                case ("open email."):
                case ("rosita open email."):
                case ("rosita open outlook."):
                case ("rosita open outlook for me."):
                case ("rosita open outlook for me please."):
                    greeting = "Ok, opening emails";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process0 = new Process();
                    process0.StartInfo.UseShellExecute = true;
                    process0.StartInfo.FileName = "outlook";
                    process0.Start();
                    break;
                case ("rosita open spotify."):
                case ("open spotify."):
                case ("spotify."):
                case ("rosita open spotify for me."):
                case ("rosita open spotify for me please."):
                case ("open spotify for me please."):
                    greeting = "Ok, opening spotify";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process01 = new Process();
                    process01.StartInfo.UseShellExecute = true;
                    process01.StartInfo.FileName = "C:\\Program Files (x86)\\Spotify\\Spotify";
                    process01.Start();
                    break;
                case ("rosita open steam for me please."):
                    greeting = "Ok, opening steam for you";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process02 = new Process();
                    process02.StartInfo.UseShellExecute = true;
                    process02.StartInfo.FileName = "R:\\Steam\\steam";
                    process02.Start();
                    break;
                case ("youtube."):
                case ("open youtube."):
                case ("rosita open youtube."):
                    greeting = "Ok, opening youtube";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = "chrome";
                    process.StartInfo.Arguments = @"https://www.youtube.com/";
                    process.Start();
                    break;
                case ("play jacksons show on youtube."):
                case ("play jackson show on youtube."):
                case ("play spanish kid show on youtube."):
                case ("play spanish clown show on youtube."):
                    greeting = "Ok, playing spanish cartoon";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process1 = new Process();
                    process1.StartInfo.UseShellExecute = true;
                    process1.StartInfo.FileName = "chrome";
                    process1.StartInfo.Arguments = @"https://www.youtube.com/watch?v=aLninKfWN4M&list=PLW_5GrNJG1WhPOAE881KDTURaptRPJ_r4&index=3&t=0s";
                    process1.Start();
                    break;
                case ("google search."):
                case ("rosita search google."):
                case ("rosita search google for me."):
                case ("rosita google something for me please."):
                case ("rosita google something for me please?"):
                case ("rosita google something for me."):
                    greeting = "what would you like to search for?";
                    SynthesizeAudioAsync(greeting).Wait();
                    {
                        var config1 =
                        SpeechConfig.FromSubscription(
                        "aabb8086039843e7b4339dd4928f2de1",
                        "eastus");
                        using var audioConfig1 = AudioConfig.FromDefaultMicrophoneInput();
                        using var recognizer1 = new SpeechRecognizer(config1, audioConfig1);
                        Console.WriteLine("Say something...");
                        var result1 = await recognizer1.RecognizeOnceAsync();
                        string command1 = result1.Text;
                        string[] words = command1.Split(' ');
                        greeting = $"Ok searching for...{command1}";
                        SynthesizeAudioAsync(greeting).Wait();
                        Process process3 = new Process();
                        process3.StartInfo.UseShellExecute = true;
                        process3.StartInfo.FileName = "chrome";
                        process3.StartInfo.Arguments = @"https://www.google.com/search?q=" + string.Join("+", words);
                        process3.Start();
                    }
                    break;
                case ("bing search."):
                case ("rosita search bing."):
                case ("rosita search bing for me."):
                case ("rosita bing something for me please."):
                case ("rosita bing something for me please?"):
                case ("rosita bing something for me."):
                    greeting = "what would you like to search for?";
                    SynthesizeAudioAsync(greeting).Wait();
                    {
                        var config1 =
                        SpeechConfig.FromSubscription(
                        "aabb8086039843e7b4339dd4928f2de1",
                        "eastus");
                        using var audioConfig1 = AudioConfig.FromDefaultMicrophoneInput();
                        using var recognizer1 = new SpeechRecognizer(config1, audioConfig1);
                        Console.WriteLine("Say something...");
                        var result1 = await recognizer1.RecognizeOnceAsync();
                        string command1 = result1.Text;
                        string[] words = command1.Split(' ');
                        greeting = $"Ok searching for...{command1}";
                        SynthesizeAudioAsync(greeting).Wait();
                        Process process4 = new Process();
                        process4.StartInfo.UseShellExecute = true;
                        process4.StartInfo.FileName = "chrome";
                        process4.StartInfo.Arguments = @"https://www.bing.com/search?q=" + string.Join("+", words);
                        process4.Start();
                    }
                    break;
                case ("youtube search."):
                case ("rosita search youtube."):
                case ("rosita search youtube for me."):
                    greeting = "what would you like to search for?";
                    SynthesizeAudioAsync(greeting).Wait();
                    {
                        var config1 =
                        SpeechConfig.FromSubscription(
                        "aabb8086039843e7b4339dd4928f2de1",
                        "eastus");
                        using var audioConfig1 = AudioConfig.FromDefaultMicrophoneInput();
                        using var recognizer1 = new SpeechRecognizer(config1, audioConfig1);
                        Console.WriteLine("Say something...");
                        var result1 = await recognizer1.RecognizeOnceAsync();
                        string command1 = result1.Text;
                        string[] words = command1.Split(' ');
                        greeting = $"Ok searching for...{command1}";
                        SynthesizeAudioAsync(greeting).Wait();
                        Process process5 = new Process();
                        process5.StartInfo.UseShellExecute = true;
                        process5.StartInfo.FileName = "chrome";
                        process5.StartInfo.Arguments = @"https://www.youtube.com/search?q=" + string.Join("+", words);
                        process5.Start();
                    }
                    break;
                case ("linkedin."):
                case ("open linkedin."):
                case ("rosita open linkedin."):
                    greeting = "Ok, opening youtube";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process20 = new Process();
                    process20.StartInfo.UseShellExecute = true;
                    process20.StartInfo.FileName = "chrome";
                    process20.StartInfo.Arguments = @"https://www.linkedin.com/feed/";
                    process20.Start();
                    break;
                case ("rosita close chrome."):
                case ("close chrome."):
                    greeting = "Ok, closing chrome";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process[] chromeInstances = Process.GetProcessesByName("chrome");
                    foreach (Process p in chromeInstances)
                        p.Kill();
                    break;
                case ("start a timer."):
                    greeting = "Ok, how long?";
                    SynthesizeAudioAsync(greeting).Wait();
                    {
                        var config1 =
                        SpeechConfig.FromSubscription(
                        "aabb8086039843e7b4339dd4928f2de1",
                        "eastus");
                        using var audioConfig1 = AudioConfig.FromDefaultMicrophoneInput();
                        using var recognizer1 = new SpeechRecognizer(config1, audioConfig1);
                        Console.WriteLine("How long?");
                        var result1 = await recognizer1.RecognizeOnceAsync();
                        string command1 = result1.Text;
                        string[] words = command1.Split(' ');
                        Console.WriteLine($"{words[0]},{words[1]} ");
                        greeting = $"Ok counting down {command1}";
                        SynthesizeAudioAsync(greeting).Wait();
                        string num = words[0];
                       
                        int time = Convert.ToInt32(words[0]);
                                               
                        if (words[1] == "mintue"&& words[3]=="seconds." || words[1] == "mintues" && words[3] == "seconds.")
                        {
                            time = (time * 60);
                            int time2 = Convert.ToInt32(words[2]);
                            time += time2;
                            int countdown = time * 1000;
                            for (int i = time; i > 0; i--)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine(i);
                            }

                        }


                        else if (words[1] == "mintue." || words[1] == "mintues.")
                        {
                            time = (time * 60);
                            for (int i = time; i > 0; i--)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine(i);
                            }
                        }

                        else if (words[1] == "seconds.")
                        {
                            
                            for (int i = time; i >0; i--)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            greeting = $"I didnt catch that ";
                            SynthesizeAudioAsync(greeting).Wait();
                        }
                        greeting = $"countdown complete";
                        SynthesizeAudioAsync(greeting).Wait();
                    }
                    break;
                default:
                    notInSwitch = 1;
                    break;
                
            }
            if (notInSwitch == 1)
            {
                string[] words1 = phrase.ToLower().Split(' ');
                
                if (words1[0] == "what" && words1[1] == "is" || words1[0] == "search" || words1[0] == "how" || words1[0] == "who" || words1[0] == "where" || words1[0] == "when" || words1[0] == "why")
                {
                    greeting = $"searching for...{phrase}";
                    SynthesizeAudioAsync(greeting).Wait();
                    Process process30 = new Process();
                    process30.StartInfo.UseShellExecute = true;
                    process30.StartInfo.FileName = "chrome";
                    process30.StartInfo.Arguments = @"https://www.google.com/search?q=" + string.Join("+", words1);
                    process30.Start();
                }
                if (words1[0] == "play" && words1[words1.Length-1] == "spotify.")
                {
                    words1[0] = "playing";
                    greeting = string.Join(" ",words1);
                    SynthesizeAudioAsync(greeting).Wait();
                    string[] words2;
                    words2 = words1;
                    for(int i = 0;i<words2.Length; i++)
                    {
                        if (words2[i] == "by")
                        {
                            words2[i] = "%20";
                        }
                        if (words2[i] == "spotify.")
                        {
                            words2[i] = "%20";
                        }
                        if (words2[i] == "on")
                        {
                            words2[i] = "%20";
                        }
                        if (words2[i] == "play"|| words2[i] == "playing")
                        {
                            words2[i] = "%20";
                        }


                    }
                    Process process30 = new Process();
                    process30.StartInfo.UseShellExecute = true;
                    process30.StartInfo.FileName = "chrome";
                    process30.StartInfo.Arguments = @"https://open.spotify.com/search/" + string.Join("%20", words2);  //NEED TO MAKE IT WHERE IT PLAYS AFTER OPENING/////////////////////////////////
                    process30.Start();
                    
                }
                else
                {
                    greeting = $"I don't have a command for that..sorry..try again";
                    SynthesizeAudioAsync(greeting).Wait();
                    Console.WriteLine(words1[words1.Length - 1]);
                }
            }
            
        }
        public static async Task SynthesizeAudioAsync(string greeting)
        {
            var config = SpeechConfig.FromSubscription("aabb8086039843e7b4339dd4928f2de1",
                    "eastus");
            using var synthesizer = new SpeechSynthesizer(config);
            await synthesizer.SpeakTextAsync(greeting);
        }
        public static async Task Greeting()
        {
            Random random = new Random();
            int hello = random.Next(0, 4);
            string greeting;
            switch (hello)
            {
                case 0:
                    greeting = $"Heyy Johnny...what do you need help with?";
                    await SynthesizeAudioAsync(greeting);
                    break;
                case 1:
                    greeting = $"Helloo Johnny!";
                    await SynthesizeAudioAsync(greeting);
                    break;
                case 2:
                    greeting = $"How may I help you";
                    await SynthesizeAudioAsync(greeting);
                    break;
                case 3:
                    if (DateTime.Now.Hour < 12)
                    {
                        greeting = $"Good Morning";
                        await SynthesizeAudioAsync(greeting);
                    }
                    if (DateTime.Now.Hour > 11 && DateTime.Now.Hour < 17)
                    {
                        greeting = $"Good Afternoon";
                        await SynthesizeAudioAsync(greeting);
                    }
                    if (DateTime.Now.Hour > 17)
                    {
                        greeting = $"Good Evening";
                        await SynthesizeAudioAsync(greeting);
                    }
                    break;
                case 4:
                    greeting = $"Welcome back!";
                    await SynthesizeAudioAsync(greeting);
                    break;
            }

        }
        public string ConvertNumber(string num)
        {
            if (num == "one")
            {
                return "1";
            }
            if (num == "two")
            {
                return "2";
            }
            if (num == "three")
            {
                return "3";
            }
            if (num == "four")
            {
                return "4";
            }
            if (num == "five")
            {
                return "5";
            }
            if (num == "six")
            {
                return "6";
            }
            if (num == "seven")
            {
                return "7";
            }
            if (num == "eight")
            {
                return "8";
            }
            if (num == "nine")
            {
                return "9";
            }
            else
            {
                return "10";
            }
            
        }
    }
}

