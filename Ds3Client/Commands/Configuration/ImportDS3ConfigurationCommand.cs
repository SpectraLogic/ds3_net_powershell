﻿/*
 * ******************************************************************************
 *   Copyright 2014 Spectra Logic Corporation. All Rights Reserved.
 *   Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *   this file except in compliance with the License. A copy of the License is located at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 *   or in the "license" file accompanying this file.
 *   This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *   CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *   specific language governing permissions and limitations under the License.
 * ****************************************************************************
 */

using Ds3Client.Configuration;
using System.IO;
using System.Management.Automation;
using Config = Ds3Client.Configuration.Configuration;

namespace Ds3Client.Commands.Configuration
{
    [Cmdlet(VerbsData.Import, DS3Nouns.Configuration)]
    public class ImportDS3ConfigurationCommand : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Path { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public SwitchParameter MakeSelected { get; set; }

        protected override void EndProcessing()
        {
            // Parse the config, set the name, and validate it.
            Config config;
            using (var configFile = File.OpenRead(Path))
            {
                config = ConfigurationParser.Parse(configFile);
            }
            config.Name = Name ?? config.Name ?? System.IO.Path.GetFileNameWithoutExtension(Path);
            ConfigurationParser.ValidateConfiguration(config);

            // Import the config and optionally select it.
            var session = SessionSingleton.Current;
            session.Import(config);
            if (MakeSelected.IsPresent)
            {
                session.Select(config.Name);
            }

            // Send the new config to the output.
            WriteObject(config);
        }
    }
}
