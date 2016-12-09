﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using XCommon.Extensions.Checks;
using XCommon.Test.Extensions.Checks.DataSource;
using XCommon.Util;
using Xunit;

namespace XCommon.Test.Extensions.Checks
{
    public class ValueCheckTest
    {
        [Theory(DisplayName = "GreaterThan DateTime")]
        [MemberData(nameof(ValueCheckDataSource.GreaterThanDateTimeDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void GreaterThanDateTime(Pair<DateTime, DateTime> data, bool expected, string message)
        {
            bool result = data.Item1.GreaterThan(data.Item2);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "GreaterThan DateTime (Without time)")]
        [MemberData(nameof(ValueCheckDataSource.GreaterThanDateTimeNoTimeDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void GreaterThanDateTimeNoTime(Pair<DateTime, DateTime> data, bool expected, string message)
        {
            bool result = data.Item1.GreaterThan(data.Item2, true);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "GreaterThan Int")]
        [MemberData(nameof(ValueCheckDataSource.GreaterThanIntDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void GreaterThanInt(int from, int to, bool expected, string message)
        {
            bool result = from.GreaterThan(to);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "GreaterThan Decimal")]
        [MemberData(nameof(ValueCheckDataSource.GreaterThanDecimalDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void GreaterThanDecimal(decimal from, decimal to, bool expected, string message)
        {
            bool result = from.GreaterThan(to);
            
            expected.Should().Be(result, message);
        }
        
        [Theory(DisplayName = "LessThan DateTime")]
        [MemberData(nameof(ValueCheckDataSource.LessThanDateTimeDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void LessThanDateTime(Pair<DateTime, DateTime> data, bool expected, string message)
        {
            bool result = data.Item1.LessThan(data.Item2);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "LessThan DateTime (Without time)")]
        [MemberData(nameof(ValueCheckDataSource.LessThanDateTimeNoTimeDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void LessThanDateTimeNoTime(Pair<DateTime, DateTime> data, bool expected, string message)
        {
            bool result = data.Item1.LessThan(data.Item2, true);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "LessThan Int")]
        [MemberData(nameof(ValueCheckDataSource.LessThanIntDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void LessThanInt(int from, int to, bool expected, string message)
        {
            bool result = from.LessThan(to);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "LessThan Decimal")]
        [MemberData(nameof(ValueCheckDataSource.LessThanDecimalDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void LessThanDecimal(decimal from, decimal to, bool expected, string message)
        {
            bool result = from.LessThan(to);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "InRange DateTime")]
        [MemberData(nameof(ValueCheckDataSource.InRangeDateTimeDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void InRangeDateTime(Pair<DateTime, DateTime, DateTime> data, bool expected, string message)
        {
            bool result = data.Item1.InRange(data.Item2, data.Item3);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "InRange DateTime (Without time)")]
        [MemberData(nameof(ValueCheckDataSource.InRangeDateTimeNoTimeDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void InRangeDateTimeNoTime(Pair<DateTime, DateTime, DateTime> data, bool expected, string message)
        {
            bool result = data.Item1.InRange(data.Item2, data.Item2, true);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "InRange Int")]
        [MemberData(nameof(ValueCheckDataSource.InRangeIntDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void InRangeInt(int from, int toBegin, int toEnd, bool expected, string message)
        {
            bool result = from.InRange(toBegin, toEnd);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "InRange Decimal")]
        [MemberData(nameof(ValueCheckDataSource.InRangeDecimalDataSource), MemberType = typeof(ValueCheckDataSource))]
        public void InRangeDecimal(decimal from, decimal toBegin, decimal toEnd, bool expected, string message)
        {
            bool result = from.InRange(toBegin, toEnd);

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "Valid List")]
        [MemberData(nameof(ValueCheckDataSource.GuidValidList), MemberType = typeof(ValueCheckDataSource))]
        public void ValidList(List<Guid> source, bool expected, string message)
        {
            bool result = source.IsValidList();

            expected.Should().Be(result, message);
        }

        [Theory(DisplayName = "Valid List (Ignore Empty)")]
        [MemberData(nameof(ValueCheckDataSource.GuidValidListIgnoreEmpty), MemberType = typeof(ValueCheckDataSource))]
        public void ValidListIgnoreEmpty(List<Guid> source, bool expected, string message)
        {
            bool result = source.IsValidList(true);

            expected.Should().Be(result, message);
        }
    }
}
