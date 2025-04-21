
using System;
using System.Collections.Generic;
using System.Media;
using Figgle;
using System.Threading;

namespace CyberSecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Assistant";

            // Play voice greeting (.wav file)
            PlaySound("C:\\Users\\Lenovo Flex\\OneDrive\\Documents\\PROG6221\\VisualStudio2022\\cyberBot\\greeting.wav");

            // Display ASCII art logo
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSec ChatBot"));
            Console.ResetColor();

            // Asking for user name and personalize greeting
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hello! What is your name? ");
            Console.ResetColor();
            string userName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "friend";
            }

            //making bot response colour green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Assistant.");
            Console.WriteLine("Ask me anything about staying safe online! (Type 'tips' for quick security tips) OR (Type 'what can i ask you about')\n");
            Console.ResetColor();

            // Response dictionary
            Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
               { "phishing", "Phishing Attacks:\n" +
                             " Be wary of emails/messages asking for personal info\n" +
                             " Check sender addresses carefully\n" +
                             " Never click suspicious links - hover to preview first\n" +
                             " When in doubt, contact the company directly" },

                { "passwords", "Password Security:\n" +
                              " Use 12+ characters with mix of upper/lower case, numbers & symbols\n" +
                              " Try passphrases like 'PurpleTiger$Eats_42Pizza!'\n" +
                              " Never reuse passwords across sites\n" +
                              " Use a password manager (Bitwarden, 1Password)" },

                { "safe browsing", "Safe Browsing:\n" +
                                 " Always look for HTTPS in URLs\n" +
                                 " Avoid public Wi-Fi for sensitive tasks (use VPN if needed)\n" +
                                 " Keep browsers and plugins updated\n" +
                                 " Use ad-blockers to avoid malicious ads" },

                { "2fa", "Two-Factor Authentication (2FA):\n" +
                         " Enable on all important accounts (email, banking, social media)\n" +
                         " Use authenticator apps (Google Authenticator/Authy) instead of SMS\n" +
                         " Keep backup codes in a safe place" },

                { "updates", "Software Updates:\n" +
                            " Enable automatic updates for OS and apps\n" +
                            " Regularly update router firmware\n" +
                            " Remove unused programs to reduce attack surface" },

                { "backups", "Data Backups:\n" +
                            " Follow the 3-2-1 rule: 3 copies, 2 local, 1 offsite\n" +
                            " Use encrypted cloud storage (Backblaze, Google Drive)\n" +
                            " Test restoring backups periodically" },

                { "social engineering", "Social Engineering Defense:\n" +
                                      " Verify unexpected requests (even from 'friends')\n" +
                                      " Never share passwords or codes with anyone\n" +
                                      " Be skeptical of urgent/scary messages\n" +
                                      " Train employees if you're a business owner" },

                { "tips", "Top 10 Cybersecurity Tips:\n" +
                         "1. Use strong, unique passwords\n" +
                         "2. Enable 2FA everywhere\n" +
                         "3. Watch for phishing attempts\n" +
                         "4. Keep all software updated\n" +
                         "5. Browse safely (HTTPS/VPN)\n" +
                         "6. Secure devices with encryption\n" +
                         "7. Maintain regular backups\n" +
                         "8. Be wary of social engineering\n" +
                         "9. Check app permissions\n" +
                         "10. Monitor your digital footprint\n\n"
                        },

                { "how are you", "I'm just code, but I'm functioning securely!" },
                { "what is your purpose", "I'm here to educate you about cybersecurity and help you stay safe online." },
                { "what can i ask you about", "You can ask about:\n" +
                                             " phishing\n passwords\n safe browsing\n 2fa\n updates\n" +
                                             " backups\n• social engineering\n tips\n or say 'bye' to exit" },
                { "bye", $"Goodbye, {userName}! Stay cyber safe! Remember: Security is a journey, not a destination. " }
            };

            while (true)
            {
                //users typing colour will be cyan
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                if (responses.ContainsKey(input))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Bot: {responses[input]}");
                    Console.ResetColor();

                    if (input.Equals("bye", StringComparison.OrdinalIgnoreCase))
                        break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bot: I didn’t quite understand that. Try 'tips' for security advice or 'what can i ask you about' for options.");
                    Console.ResetColor();
                }
            }
        }

        static void PlaySound(string filePath)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(filePath))
                {
                    player.Load();
                    player.PlaySync(); // Wait until the sound finishes
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing sound: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}

