﻿using XCommon.Test.Extensions.UtilTest.Sample;
using Xunit;
using XCommon.Extensions.Util;
using FluentAssertions;

namespace XCommon.Test.Extensions.UtilTest
{
    public class EnumerationExtensionsTest
    {
        [Fact(DisplayName = "Has (False)")]        
        public void HasFalse()
        {
            Profile value = Profile.Manager;

            var result = value.Has(Profile.CEO);

            result.Should().Be(false, "The profile is a manager, not a CEO");
        }

        [Fact(DisplayName = "Has (True)")]
        public void HasTrue()
        {
            Profile value = Profile.Manager;

            var result = value.Has(Profile.Manager);

            result.Should().Be(true, "The profile is a manager");
        }

        [Fact(DisplayName = "Has Multiple")]
        public void HasMultiple()
        {
            Profile value = Profile.User | Profile.Director | Profile.Manager;

            value.Has(Profile.User).Should().Be(true, "The profile is a user too");
            value.Has(Profile.Director).Should().Be(true, "The profile is a director too");
            value.Has(Profile.Manager).Should().Be(true, "The profile is a manager too");
            value.Has(Profile.SuperUser).Should().Be(false, "The profile isn't a SuperUser");
            value.Has(Profile.Supervisor).Should().Be(false, "The profile isn't a Supervisor");
            value.Has(Profile.CEO).Should().Be(false, "The profile isn't a CEO");
        }

        [Fact(DisplayName = "Add (Cast int)")]
        public void AddCast()
        {
            Profile value = Profile.User;

            value = value
                .Add(Profile.Director)
                .Add(Profile.Manager);

            int intValue = (int)value;

            intValue.Should().Be(6);
        }

        [Fact(DisplayName = "Add")]
        public void Add()
        {
            Profile value = Profile.User;

            value = value
                .Add(Profile.Director)
                .Add(Profile.Manager);

            value.Has(Profile.User).Should().Be(true, "The profile is a user too");
            value.Has(Profile.Director).Should().Be(true, "The profile is a director too");
            value.Has(Profile.Manager).Should().Be(true, "The profile is a manager too");
            value.Has(Profile.SuperUser).Should().Be(false, "The profile isn't a SuperUser");
            value.Has(Profile.Supervisor).Should().Be(false, "The profile isn't a Supervisor");
            value.Has(Profile.CEO).Should().Be(false, "The profile isn't a CEO");
        }

        [Fact(DisplayName = "Add (Twice)")]
        public void AddTwice()
        {
            Profile value = Profile.User;

            value = value
                .Add(Profile.Director)
                .Add(Profile.Manager);

            value = value
                .Add(Profile.Director);

            value.Has(Profile.User).Should().Be(true, "The profile is a user too");
            value.Has(Profile.Director).Should().Be(true, "The profile is a director too");
            value.Has(Profile.Manager).Should().Be(true, "The profile is a manager too");

            value.Has(Profile.SuperUser).Should().Be(false, "The profile isn't a SuperUser");
            value.Has(Profile.Supervisor).Should().Be(false, "The profile isn't a Supervisor");
            value.Has(Profile.CEO).Should().Be(false, "The profile isn't a CEO");
        }

        [Fact(DisplayName = "Remove")]
        public void Remove()
        {
            Profile value = Profile.User | Profile.Director | Profile.CEO | Profile.Manager;

            value = value
                .Remove(Profile.Director);

            value.Has(Profile.User).Should().Be(true, "The profile is a user too");
            value.Has(Profile.CEO).Should().Be(true, "The profile is a CEO");
            value.Has(Profile.Manager).Should().Be(true, "The profile is a manager");

            value.Has(Profile.Director).Should().Be(false, "The profile isn't a director too");
            value.Has(Profile.SuperUser).Should().Be(false, "The profile isn't a SuperUser");
            value.Has(Profile.Supervisor).Should().Be(false, "The profile isn't a Supervisor");
        }

        [Fact(DisplayName = "Remove (Twice)")]
        public void RemoveTwice()
        {
            Profile value = Profile.User | Profile.Director | Profile.CEO | Profile.Manager;

            value = value
                .Remove(Profile.Director)
                .Remove(Profile.Manager);

            value = value
                .Remove(Profile.Director);

            value.Has(Profile.User).Should().Be(true, "The profile is a user too");
            value.Has(Profile.CEO).Should().Be(true, "The profile is a CEO");

            value.Has(Profile.Director).Should().Be(false, "The profile isn't a director");
            value.Has(Profile.Manager).Should().Be(false, "The profile isn't a manager");
            value.Has(Profile.SuperUser).Should().Be(false, "The profile isn't a SuperUser");
            value.Has(Profile.Supervisor).Should().Be(false, "The profile isn't a Supervisor");
        }

        [Fact(DisplayName = "Remove (All)")]
        public void RemoveAll()
        {
            Profile value = Profile.User | Profile.Director | Profile.CEO | Profile.Manager;

            value = value
                .Remove(Profile.User)
                .Remove(Profile.Director)
                .Remove(Profile.CEO)
                .Remove(Profile.Manager);

            value.Has(Profile.User).Should().Be(true, "The profile always is a user");
            value.Has(Profile.CEO).Should().Be(false, "The profile isn't a CEO");
            value.Has(Profile.Director).Should().Be(false, "The profile isn't a director");
            value.Has(Profile.Manager).Should().Be(false, "The profile isn't a manager");
            value.Has(Profile.SuperUser).Should().Be(false, "The profile isn't a SuperUser");
            value.Has(Profile.Supervisor).Should().Be(false, "The profile isn't a Supervisor");
        }
    }
}
