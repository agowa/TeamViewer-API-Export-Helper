/*
 * Copyright (c) 2014 TeamViewer GmbH
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * When reusing or redistributing the software please respect any licenses of
 * included software from third parties, if applicable.
 */

using System;
using System.Runtime.Serialization;

namespace TeamViewer_Exporter.DataType
{
    [DataContract]
    internal class QuarryInformation
    {
        [DataMember(Name = "code")]
        internal string SessionCode { get; set; }

        [DataMember(Name = "state")]
        internal string SessionState { get; set; }

        [DataMember(Name = "groupid")]
        internal string GroupId { get; set; }

        [DataMember(Name = "groupname")]
        internal string GroupName { get; set; }

        [DataMember(Name = "waiting_message")]
        internal string WaitingMessage { get; set; }

        [DataMember(Name = "description")]
        internal string Description { get; set; }

        [DataMember(Name = "end_customer")]
        internal EndCustomer EndCustomer { get; set; }

        [DataMember(Name = "assigned_userid")]
        internal string AssignedAccountId { get; set; }

        [DataMember(Name = "assigned_at")]
        internal DateTime? AssignedAt { get; set; }

        [DataMember(Name = "end_customer_link")]
        internal string EndCustomerLink { get; set; }

        [DataMember(Name = "supporter_link")]
        internal string SupporterLink { get; set; }

        [DataMember(Name = "created_at")]
        internal DateTime? CreatedAt { get; set; }

        [DataMember(Name = "valid_until")]
        internal DateTime? ValidUntil { get; set; }

        internal string UnformatedJsonString { get; set; }
        internal string FormatedJsonString { get; set; }
    }
}