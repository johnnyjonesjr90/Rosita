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
    public class Program
    {
        public static int Exit { get; set; }
        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Speech.Greeting().Wait();
            while (Exit == 0)
            {
                RecognizeSpeechAsync().Wait();
            }
            
        }
       //////////////////////////////////////////////////////////////   LISTENING COMMANDS   ////////////////////////////////////////////////////////////////////////////////////
        public static async Task RecognizeSpeechAsync()
        {
            Console.Clear();
            Console.WriteLine("Please Say 'Hey Rosita' to begin");
            var keywordModel = KeywordRecognitionModel.FromFile("C:\\Users\\Johnny\\source\\repos\\Rosita\\827f85af-e8cd-44ad-8d48-1963414c3bde.table");
            using var audioConfig10 = AudioConfig.FromDefaultMicrophoneInput();
            using var keywordRecognizer = new KeywordRecognizer(audioConfig10);
            KeywordRecognitionResult keyresult = await keywordRecognizer.RecognizeOnceAsync(keywordModel);
            var config =
                SpeechConfig.FromSubscription(
                    "aabb8086039843e7b4339dd4928f2de1",
                    "eastus");
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(config, audioConfig);
            
            Console.WriteLine("Say something...");
            var result = await recognizer.RecognizeOnceAsync();
            string command = result.Text;

            switch (result.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                    break;
                case ResultReason.NoMatch:
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    break;
                case ResultReason.Canceled:
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                    break;
                
            }
            //////////////////////////////////////////////////////////////   LISTENING COMMANDS END   /////////////////////////////////////////////////////////////////////////
            ///
            /// 
            /// 
            /////////////////////////////////////////////////////////////////////   LINK TO KEY PHRASES   ////////////////////////////////////////////////////////////////////////////
            
            await Speech.TalkingAsync(command.ToLower());

            /////////////////////////////////////////////////////////////////////   LINK TO KEY PHRASES END  ////////////////////////////////////////////////////////////////////////////

        }
        




    }
}