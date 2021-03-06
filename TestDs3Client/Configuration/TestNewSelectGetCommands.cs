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

using NUnit.Framework;
using System.Collections.ObjectModel;
using Config = Ds3Client.Configuration.Configuration;

namespace TestDs3Client.Configuration
{
    [TestFixture]
    public class TestNewSelectGetCommands
    {
        [Test]
        public void TestNewSelectGet()
        {
            using (var runspace = Helpers.SetUpRunspace())
            {
                // Add two configs and make sure get returns both.
                Helpers.RunAndTestNew(runspace, Helpers.SuccessConfig, ps => ps.AddParameter("DontPersist"));
                Helpers.RunAndTestNew(runspace, Helpers.AdditionalConfig, ps => ps.AddParameter("DontPersist"));
                Helpers.RunAndTestGet(runspace, new Collection<Config> { Helpers.SuccessConfig, Helpers.AdditionalConfig });

                // Select the first config and make sure get shows selected and get selected shows the correct one.
                var selectedSuccessConfig = Helpers.CopyConfig(Helpers.SuccessConfig);
                selectedSuccessConfig.IsSelected = true;
                Helpers.RunAndTestSelect(runspace, selectedSuccessConfig);
                Helpers.RunAndTestGet(runspace, new Collection<Config> { selectedSuccessConfig, Helpers.AdditionalConfig });
                Helpers.RunAndTestGet(runspace, new Collection<Config> { selectedSuccessConfig }, ps => ps.AddParameter("Selected"));

                // Select the second config and make sure get shows selected and get selected shows the correct one.
                var selectedAdditionalConfig = Helpers.CopyConfig(Helpers.AdditionalConfig);
                selectedAdditionalConfig.IsSelected = true;
                Helpers.RunAndTestSelect(runspace, selectedAdditionalConfig);
                Helpers.RunAndTestGet(runspace, new Collection<Config> { Helpers.SuccessConfig, selectedAdditionalConfig });
                Helpers.RunAndTestGet(runspace, new Collection<Config> { selectedAdditionalConfig }, ps => ps.AddParameter("Selected"));

                // Get by name to make sure that parameter works.
                Helpers.RunAndTestGet(runspace, new Collection<Config> { Helpers.SuccessConfig }, ps => ps.AddArgument(Helpers.SuccessConfig.Name));
                Helpers.RunAndTestGet(runspace, new Collection<Config> { selectedAdditionalConfig }, ps => ps.AddArgument(selectedAdditionalConfig.Name));
            }
        }
    }
}
