﻿//******************************************************************************************************
//  MetadataBase.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
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
//  12/14/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//
//******************************************************************************************************

using System;
using openVisN.Calculations;

namespace openVisN
{
    public abstract class MetadataBase
        : ValueTypeConversionBase
    {
        public Guid UniqueId { get; private set; }
        public long HistorianId { get; private set; }
        public abstract EnumValueType ValueType { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CalculationMethod Calculations { get; private set; }

        protected MetadataBase(Guid uniqueId, long historianId, string name, string description, CalculationMethod calculations)
        {
            if (calculations == null)
            {
                calculations = CalculationMethod.Empty;
            }
            Calculations = calculations;
            UniqueId = uniqueId;
            HistorianId = historianId;
            Name = name;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            MetadataBase obj2 = obj as MetadataBase;
            if (obj2 == null)
                return false;
            return obj2.UniqueId == UniqueId;
        }
        public override int GetHashCode()
        {
            return UniqueId.GetHashCode();
        }
    }

    public unsafe class MetadataSingle : MetadataBase
    {
        public MetadataSingle(Guid uniqueId, long historianId, string name, string description, CalculationMethod calculations = null)
            : base(uniqueId, historianId, name, description, calculations)
        {
        }

        public override EnumValueType ValueType
        {
            get
            {
                return EnumValueType.Single;
            }
        }

        protected override ulong ToRaw(IConvertible value)
        {
            float tmp = value.ToSingle(null);
            return *(uint*)&tmp;
        }

        protected override IConvertible GetValue(ulong value)
        {
            return *(float*)&value;
        }
    }

    public unsafe class MetadataDouble : MetadataBase
    {
        public MetadataDouble(Guid uniqueId, long historianId, string name, string description, CalculationMethod calculations = null)
            : base(uniqueId, historianId, name, description, calculations)
        {
        }

        public override EnumValueType ValueType
        {
            get
            {
                return EnumValueType.Single;
            }
        }

        protected override IConvertible GetValue(ulong value)
        {
            return *(double*)&value;
        }

        protected override ulong ToRaw(IConvertible value)
        {
            double tmp = value.ToDouble(null);
            return *(ulong*)&tmp;
        }
    }
}
