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

using System.Management.Automation;
using System.IO;

namespace Ds3Client.Commands.Api
{
    [Cmdlet(VerbsCommon.Remove, DS3Nouns.Object)]
    public class RemoveObjectCommand : BaseApiCommand
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public string BucketName { get; set; }

        [Alias(new string[] { "Name" })]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public string Key { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            var confirmString = string.Format(Resources.ObjectDescription, Key, BucketName);
            if (Force.IsPresent || (ShouldProcess(confirmString) && ShouldContinue(Resources.RemoveObjectConfirmationMessage, confirmString)))
            {
                CreateClient().DeleteObject(new Ds3.Calls.DeleteObjectRequest(BucketName, Key));
            }
        }
    }
}
