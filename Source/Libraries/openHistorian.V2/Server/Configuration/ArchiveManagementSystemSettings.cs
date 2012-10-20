﻿//******************************************************************************************************
//  ArchiveManagementSystemSettings.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  7/24/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************

using openHistorian.V2.Collections;

namespace openHistorian.V2.Server.Configuration
{
    public class ArchiveManagementSystemSettings 
    {
        public string Name { get; private set; }
        public ArchiveWriterSettings ArchiveWriter;
        public ReadonlyList<ArchiveManagementSettings> ArchiveManagers;
        public ArchiveListSettings ArchiveList;
       
        public ArchiveManagementSystemSettings(ConfigNode node)
        {
            Name = node.GetChildString("Name", "default");
            if (node.Contains("ArchiveWriter"))
                ArchiveWriter = new ArchiveWriterSettings(node.GetChild("ArchiveWriter"));  
            ArchiveManagers = new ReadonlyList<ArchiveManagementSettings>();
            foreach (var n in node.GetChildren())
            {
                ArchiveManagers.Add(new ArchiveManagementSettings(n));
            }
            ArchiveList = new ArchiveListSettings(node);

            ArchiveManagers.IsReadOnly = true;
        }

    }

}
