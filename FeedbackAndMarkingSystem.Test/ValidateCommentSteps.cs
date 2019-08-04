using FeedbackAndMarkingSystem.Common.Models;
using FeedbackAndMarkingSystem.Logic;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace FeedbackAndMarkingSystem.Test
{
    [Binding]
    public class ValidateCommentSteps
    {
        private Comment comment;
        bool result;
        string message;

        public ValidateCommentSteps()
        {
            comment = new Comment();
        }
        
        [Given(@"the assessor has specified (.*) for the assignment code")]
        public void GivenTheAssessorHasSpecifiedForTheAssignmentCode(string p0)
        {
            comment.AssignmentCode = p0;
        }
        
        [Given(@"they have specified (.*) as the title")]
        public void GivenTheyHaveSpecifiedAsTheTitle(string p0)
        {
            comment.Title = p0;
        }

        [Given(@"they have specified (.*) for the comment text")]
        public void GivenTheyHaveSpecifiedForTheCommentText(string p0)
        {
            comment.CommentText = p0;
        }

        [Given(@"they have selected (.*) as the comment type")]
        public void GivenTheyHaveSelectedAsTheCommentType(string p0)
        {
            comment.CommentType = p0;
        }

        [Given(@"they have entered (.*) for Comment Type value")]
        public void GivenTheyHaveEnteredForCommentTypeValue(int p0)
        {
            comment.CommentTypeValue1 = p0;
        }

        [Given(@"they have entered (.*) for the Grade Band lower value")]
        public void GivenTheyHaveEnteredForTheGradeBandLowerValue(int p0)
        {
            comment.CommentTypeValue1 = p0;
        }

        [Given(@"they have entered (.*) for the Grade Band upper value")]
        public void GivenTheyHaveEnteredForTheGradeBandUpperValue(int p0)
        {
            comment.CommentTypeValue2 = p0;
        }

        [When(@"they click submit")]
        public void WhenTheyClickSubmit()
        {
           CommentValidation.ValidateComment(comment, out message, out result);
        }
        
        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(string p0)
        {
            Assert.Equal(Boolean.Parse(p0), result);
        }

        [Then(@"the message is '(.*)'")]
        public void ThenTheMessageIs(string p0)
        {
            Assert.Equal(p0, message);
        }

    }
}
