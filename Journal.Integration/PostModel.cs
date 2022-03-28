﻿using System.Collections.Generic;

namespace Journal.Model
{
    public class PostModel: BaseModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Description { get; set; }
        public List<CommentModel> Comments { get; set; }
        public CategoryModel Category { get; set; }
    }
}
