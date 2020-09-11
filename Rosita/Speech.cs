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


namespace Rosita
{

    public class Speech
    {
        public static async Task TalkingAsync(string phrase)
        {
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
                        Process process2 = new Process();
                        process2.StartInfo.UseShellExecute = true;
                        process2.StartInfo.FileName = "chrome";
                        process2.StartInfo.Arguments = @"https://www.google.com/search?q=" + string.Join("+", words);
                        process2.Start();
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
                        Process process2 = new Process();
                        process2.StartInfo.UseShellExecute = true;
                        process2.StartInfo.FileName = "chrome";
                        process2.StartInfo.Arguments = @"https://www.bing.com/search?q=" + string.Join("+", words);
                        process2.Start();
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
                        Process process2 = new Process();
                        process2.StartInfo.UseShellExecute = true;
                        process2.StartInfo.FileName = "chrome";
                        process2.StartInfo.Arguments = @"https://www.youtube.com/search?q=" + string.Join("+", words);
                        process2.Start();
                    }
                    break;
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
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case 1:
                    greeting = $"Helloo Johnny!";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case 2:
                    greeting = $"How may I help you";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
                case 3:
                    if (DateTime.Now.Hour < 12)
                    {
                        greeting = $"Good Morning";
                        SynthesizeAudioAsync(greeting).Wait();
                    }
                    if (DateTime.Now.Hour > 11 && DateTime.Now.Hour < 17)
                    {
                        greeting = $"Good Afternoon";
                        SynthesizeAudioAsync(greeting).Wait();
                    }
                    if (DateTime.Now.Hour > 17)
                    {
                        greeting = $"Good Evening";
                        SynthesizeAudioAsync(greeting).Wait();
                    }
                    break;
                case 4:
                    greeting = $"Welcome back!";
                    SynthesizeAudioAsync(greeting).Wait();
                    break;
            }
        }
    }
}

