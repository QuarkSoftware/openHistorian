﻿//******************************************************************************************************
//  ArchiveFileStateInformation.cs - Gbtc
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
//  7/18/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************


namespace openHistorian.V2.Server.Database
{
    /// <summary>
    /// Metadata maintained by <see cref="ArchiveList"/> about each archive file.
    /// </summary>
    public class ArchiveFileStateInformation
    {
        /// <summary>
        /// Determines if the archive supports editing.
        /// </summary>
        public bool IsReadOnly;
        /// <summary>
        /// Determines if the archive is currently locked for edits by another process.
        /// </summary>
        public bool IsEditLocked;
        /// <summary>
        /// The name of the archive generation.
        /// </summary>
        public string Generation;

        public ArchiveFileSummary Summary;

        public ArchiveFileStateInformation(bool isReadOnly, bool isEditLocked, string generation)
        {
            IsReadOnly = isReadOnly;
            IsEditLocked = isEditLocked;
            Generation = generation;
        }
    }
}
