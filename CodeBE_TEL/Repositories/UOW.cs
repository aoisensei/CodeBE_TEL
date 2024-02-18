using CodeBE_TEL.Models;

namespace CodeBE_TEL.Repositories
{
    public interface IUOW
    {
        IBoardRepository BoardRepository { get; }
        IJobRepository JobRepository { get; }
        IClassroomRepository ClassroomRepository { get; }
        IClassEventRepository ClassEventRepository { get; }
        ICommentRepository  CommentRepository { get; }
        IQuestionRepository QuestionRepository { get; }
    }
    public class UOW : IUOW
    {
        private DataContext DataContext;
        public IBoardRepository BoardRepository { get; private set; }
        public IJobRepository JobRepository { get; private set; }
        public IClassroomRepository ClassroomRepository { get; private set; }
        public IClassEventRepository ClassEventRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }

        public UOW(DataContext DataContext)
        {
            this.DataContext = DataContext;
            this.BoardRepository = new BoardRepository(DataContext);
            this.JobRepository = new JobRepository(DataContext);
            this.ClassroomRepository = new ClassroomRepository(DataContext);
            this.ClassEventRepository = new ClassEventRepository(DataContext);
            this.CommentRepository = new CommentRepository(DataContext);
            this.QuestionRepository = new QuestionRepository(DataContext);
        }
    }
}
