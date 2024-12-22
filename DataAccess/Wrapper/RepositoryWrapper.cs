using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Wrapper;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private projectDBContext _repoContext;

        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        private ICommentRepository _comment;
        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null)
                {
                    _comment = new CommentRepository(_repoContext);
                }
                return _comment;
            }
        }

        private ICommentRateRepository _commentRate;
        public ICommentRateRepository CommentRate
        {
            get
            {
                if (_commentRate == null)
                {
                    _commentRate = new CommentRateRepository(_repoContext);
                }
                return _commentRate;
            }

        }

        private IContentRepository _content;
        public IContentRepository Content
        {
            get
            {
                if (_content == null)
                {
                    _content = new ContentRepository(_repoContext);
                }
                return _content;
            }
        }

        private IFileRepository _files;
        public IFileRepository Files
        {
            get
            {
                if (_files == null)
                {
                    _files = new FileRepository(_repoContext);
                }
                return _files;
            }
        }

        private IMediaFileRepository _mediaFile;
        public IMediaFileRepository MediaFile
        {
            get
            {
                if (_mediaFile == null)
                {
                    _mediaFile = new MediaFileRepository(_repoContext);
                }
                return _mediaFile;
            }
        }

        private IMediumRepository _medium;
        public IMediumRepository Medium
        {
            get
            {
                if (_medium == null)
                {
                    _medium = new MediumRepository(_repoContext);
                }
                return _medium;
            }
        }
        private IMessagesUserRepository _messagesUser;
        public IMessagesUserRepository MessagesUser
        {
            get
            {
                if (_messagesUser == null)
                {
                    _messagesUser = new MessagesUserRepository(_repoContext);
                }
                return _messagesUser;
            }
        }

        private IMyRatingRepository _myRating;
        public IMyRatingRepository MyRating
        {
            get
            {
                if (_myRating == null)
                {
                    _myRating = new MyRatingRepository(_repoContext);
                }
                return _myRating;
            }
        }

        private IPaymentRepository _payment;
        public IPaymentRepository Payment
        {
            get
            {
                if (_payment == null)
                {
                    _payment = new PaymentRepository(_repoContext);
                }
                return _payment;
            }
        }

        private IPaymentUserRepository _paymentUser;
        public IPaymentUserRepository PaymentUser
        {
            get
            {
                if (_paymentUser == null)
                {
                    _paymentUser = new PaymentUserRepository(_repoContext);
                }
                return _paymentUser;
            }
        }

        private IRoomRepository _room;
        public IRoomRepository Room
        {
            get
            {
                if (_room == null)
                {
                    _room = new RoomRepository(_repoContext);
                }
                return _room;
            }
        }

        private IRoomsUserRepository _roomsUser;
        public IRoomsUserRepository RoomsUser
        {
            get
            {
                if (_roomsUser == null)
                {
                    _roomsUser = new RoomsUserRepository(_repoContext);
                }
                return _roomsUser;
            }

        }
        private IGroupMediumRepository _groupMedium;
        public IGroupMediumRepository GroupMedium
        {
            get
            {
                if (_groupMedium == null)
                {
                    _groupMedium = new GroupMediumRepository(_repoContext);
                }
                return _groupMedium;
            }
        }

        public RepositoryWrapper(projectDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
