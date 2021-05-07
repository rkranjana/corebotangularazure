// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.12.2


using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chatbotcore.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        // private readonly FlightBookingRecognizer _luisRecognizer;
        protected readonly ILogger Logger;

        private const string OriginStepMsgText = "Which type of component are you looking for?? (say autocomplete / button / card / form / table/others) ";
        private const string Listof = "List of components is as follows: Choose the requirde one";
        private const string getWeatherMessageText = "hi";

        string[] Right = { "YES", "yes", "Y" };

        string[] ComponentType = { "AutoComplete", "Badge", "Bottomsheet", "Button", "ButtonToggle", "Card", "Checkbox", "Chips", "Datepicker", "Dialog", "Divider", "Expansionpanel", "Formfield", "Icon", "Input", "List", "Menu", "Paginator", "Progressbar", "Progressspinner", "Radiobutton", "Ripples", "Select", "Sidenav", "Slidetoggle", "Slider", "Snackbar", "Sortheader", "Stepper", "Table", "Tabs", "Toolbar", "Tooltip" };

        private const int id = 1;




        // Dependency injection uses this constructor to instantiate MainDialog
        public MainDialog(ILogger<MainDialog> logger)
            : base(nameof(MainDialog))
        {

            Logger = logger;

            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                IntroStepAsync,
                OriginStepAsync,

                ListTrialAsync,
                ListStepAsync,
                ListCardAsync


            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }
        // to give an intro
        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {


            // Use the text provided in FinalStepAsync or the default if it is the first time.
            var messageText = stepContext.Options?.ToString() ?? "What can I help you with today?\nSay something like \"Help me explore various of angular components\"";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }

        // to ask for whether searching for components
        private async Task<DialogTurnResult> OriginStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var componentList = (CoreBot.ComponentList)stepContext.Options;



            //componentList.choice = (string)stepContext.Result;

            var messageText = $"Are you searching for angular components??";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);

            return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }

        //asking for type of component

        private async Task<DialogTurnResult> ListTrialAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if ((bool)stepContext.Result)
            {
                var componentList = (CoreBot.ComponentList)stepContext.Options;



                var promptMessage = MessageFactory.Text(OriginStepMsgText, OriginStepMsgText, InputHints.IgnoringInput);
                return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);

                // return await stepContext.NextAsync(componentList.name, cancellationToken);
                //return await stepContext.EndDialogAsync(componentList, cancellationToken);
            }
            else
            {

                var messageText = "For more angular materials check out at https://material.angular.io/  /*** Type okay to check out angular components***/";
                var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);

                await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);

                return await stepContext.EndDialogAsync(null, cancellationToken);
            }


        }

        private async Task<DialogTurnResult> ListStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var componentList = (CoreBot.ComponentList)stepContext.Options;



            switch ((string)stepContext.Result)
            {
                case ("autocomplete"):
                    {
                        var detailMessageText = "API REFERENCE: import {MatAutocompleteModule} from '@angular/material/autocomplete';   /* For more details check out at https://material.angular.io/components/autocomplete/overview */";
                        var detailMessage = MessageFactory.Text(detailMessageText, detailMessageText, InputHints.IgnoringInput);
                        await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = detailMessage }, cancellationToken);
                        break;
                    }

                case ("button"):
                    {
                        var detailMessageText = "API REFERENCE: import {MatButtonModule} from '@angular/material/button';   /* For more details check out at https://material.angular.io/components/button/overview */";
                        var detailMessage = MessageFactory.Text(detailMessageText, detailMessageText, InputHints.IgnoringInput);
                        await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = detailMessage }, cancellationToken);
                        break;
                    }

                case ("card"):
                    {
                        var detailMessageText = "API REFERENCE: import {MatCardModule} from '@angular/material/card';    /* For more details check out at https://material.angular.io/components/card/overview */";
                        var detailMessage = MessageFactory.Text(detailMessageText, detailMessageText, InputHints.IgnoringInput);
                        await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = detailMessage }, cancellationToken);
                        break;
                    }


                case ("form"):
                    {
                        var detailMessageText = "API REFERENCE: import {MatFormFieldModule} from '@angular/material/form-field';  /* For more details check out at https://material.angular.io/components/form-field/overview*/";
                        var detailMessage = MessageFactory.Text(detailMessageText, detailMessageText, InputHints.IgnoringInput);
                        await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = detailMessage }, cancellationToken);
                        break;
                    }

                case ("table"):
                    {
                        var detailMessageText = "API REFERENCE: import {MatTableModule} from '@angular/material/table';   /* For more details check out at https://material.angular.io/components/table/overview */";
                        var detailMessage = MessageFactory.Text(detailMessageText, detailMessageText, InputHints.IgnoringInput);
                        await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = detailMessage }, cancellationToken);
                        break;
                    }

                default:
                    {
                        var detailMessageText = "For entire list of components available check out at https://material.angular.io/components/categories */";
                        var detailMessage = MessageFactory.Text(detailMessageText, detailMessageText, InputHints.IgnoringInput);
                        await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = detailMessage }, cancellationToken);
                        break;
                    }

            }


            //return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
            return await stepContext.EndDialogAsync(null, cancellationToken);
        }


        private async Task<DialogTurnResult> ListCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var nextMessageText = "Type repeat to check out another component ";
            var nextMessage = MessageFactory.Text(nextMessageText, nextMessageText, InputHints.IgnoringInput);
            await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = nextMessage }, cancellationToken);

            return await stepContext.EndDialogAsync(null, cancellationToken);

        }

    }
}

