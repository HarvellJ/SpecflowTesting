using FeedbackAndMarkingSystem.Common.Models;
using System;

namespace FeedbackAndMarkingSystem.Logic
{
    public class CommentValidation
    {
        public static void ValidateComment(Comment comment, out string message, out bool result)
        {
            // null checks
            CheckForNulls(comment, out message, out result);
            if(result)
               ValidateData(comment, out message, out result);
        }

        private static void CheckForNulls(Comment comment, out string message, out bool result)
        {
            // validate assignment code
            if (string.IsNullOrEmpty(comment.AssignmentCode))
            {
                message = "Assignment Code is mandatory and must be 10 characters";
                result = false;
                return;
            }
            // validate title
            if (string.IsNullOrEmpty(comment.Title))
            {
                message = "Title field is mandatory";
                result = false;
                return;
            }
            // validate comment text
            if (string.IsNullOrEmpty(comment.CommentText))
            {
                message = "Comment Text field is mandatory";
                result = false;
                return;
            }
            // validate comment type
            if (string.IsNullOrEmpty(comment.CommentType))
            {
                message = "Comment type field is mandatory";
                result = false;
                return;
            }
         
            message = "";
            result = true;
        }

        private static void ValidateData(Comment comment, out string message, out bool result)
        {
            // validate assignment code
            if (comment.AssignmentCode.Length != 10)
            {
                message = "Assignment Code must be 10 characters";
                result = false;
                return;
            }
    
            // validate comment type
            if (!comment.CommentType.ToLower().Equals("grade band") && !comment.CommentType.ToLower().Equals("adjustment") && !comment.CommentType.ToLower().Equals("penalty") && !comment.CommentType.ToLower().Equals("late"))
            {
                message = "Invalid comment type value";
                result = false;
                return;
            }
            // validate comment type value 1
            if (comment.CommentType.ToLower().Equals("grade band"))
            {
                // check bounds
                if(comment.CommentTypeValue1 < 0)
                {
                    message = "Lower Grade band value must be >= 0";
                    result = false;
                    return;
                }
                // check bounds
                if (comment.CommentTypeValue2 > 100)
                {
                    message = "Upper Grade band value must be <=100";
                    result = false;
                    return;
                }
                // check dependency between values
                if (comment.CommentTypeValue1 >= comment.CommentTypeValue2)
                {
                    message = "Upper Grade Band value must be > the Lower Grade value";
                    result = false;
                    return;
                }              
            }

            // validate comment type value 1
            if (comment.CommentType.ToLower().Equals("adjustment"))
            {
                // check bounds
                if (comment.CommentTypeValue1 < -4)
                {
                    message = "Adjustable value must be >= -4";
                    result = false;
                    return;
                }
                if (comment.CommentTypeValue1 > 4)
                {
                    message = "Adjustable value must be <= 4";
                    result = false;
                    return;
                }
            }


            // validate comment type value 1
            if (comment.CommentType.ToLower().Equals("penalty"))
            {
                // check bounds
                if (comment.CommentTypeValue1 < 0)
                {
                    message = "Penalty value must be >= 0";
                    result = false;
                    return;
                }
                if (comment.CommentTypeValue1 > 100)
                {
                    message = "Penalty value must be <= 100";
                    result = false;
                    return;
                }
            }

            // validate comment type value 1
            if (comment.CommentType.ToLower().Equals("late"))
            {
                // check bounds
                if (comment.CommentTypeValue1 < 1)
                {
                    message = "Late value must be >= 1";
                    result = false;
                    return;
                }
                if (comment.CommentTypeValue1 > 7)
                {
                    message = "Late value must be <= 7";
                    result = false;
                    return;
                }
            }
                    // validate comment type value 2
            message = "";
            result = true;
        }
    }
}
