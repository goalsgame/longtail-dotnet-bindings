﻿namespace Longtail;
/// <summary>
/// C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\ucrt\errno.h
/// https://docs.microsoft.com/en-us/cpp/c-runtime-library/errno-constants?view=msvc-170
/// </summary>
public static class ErrorCodes
{
    public const int EPERM = 1;
    public const int ENOENT = 2;
    public const int ESRCH = 3;
    public const int EINTR = 4;
    public const int EIO = 5;
    public const int ENXIO = 6;
    public const int E2BIG = 7;
    public const int ENOEXEC = 8;
    public const int EBADF = 9;
    public const int ECHILD = 10;
    public const int EAGAIN = 11;
    public const int ENOMEM = 12;
    public const int EACCES = 13;
    public const int EFAULT = 14;
    public const int EBUSY = 16;
    public const int EEXIST = 17;
    public const int EXDEV = 18;
    public const int ENODEV = 19;
    public const int ENOTDIR = 20;
    public const int EISDIR = 21;
    public const int ENFILE = 23;
    public const int EMFILE = 24;
    public const int ENOTTY = 25;
    public const int EFBIG = 27;
    public const int ENOSPC = 28;
    public const int ESPIPE = 29;
    public const int EROFS = 30;
    public const int EMLINK = 31;
    public const int EPIPE = 32;
    public const int EDOM = 33;
    public const int EDEADLK = 36;
    public const int ENAMETOOLONG = 38;
    public const int ENOLCK = 39;
    public const int ENOSYS = 40;
    public const int ENOTEMPTY = 41;
    public const int EINVAL = 22;
    public const int ERANGE = 34;
    public const int EILSEQ = 42;
    public const int STRUNCATE = 80;
    public const int EDEADLOCK = EDEADLK;
    public const int EADDRINUSE = 100;
    public const int EADDRNOTAVAIL = 101;
    public const int EAFNOSUPPORT = 102;
    public const int EALREADY = 103;
    public const int EBADMSG = 104;
    public const int ECANCELED = 105;
    public const int ECONNABORTED = 106;
    public const int ECONNREFUSED = 107;
    public const int ECONNRESET = 108;
    public const int EDESTADDRREQ = 109;
    public const int EHOSTUNREACH = 110;
    public const int EIDRM = 111;
    public const int EINPROGRESS = 112;
    public const int EISCONN = 113;
    public const int ELOOP = 114;
    public const int EMSGSIZE = 115;
    public const int ENETDOWN = 116;
    public const int ENETRESET = 117;
    public const int ENETUNREACH = 118;
    public const int ENOBUFS = 119;
    public const int ENODATA = 120;
    public const int ENOLINK = 121;
    public const int ENOMSG = 122;
    public const int ENOPROTOOPT = 123;
    public const int ENOSR = 124;
    public const int ENOSTR = 125;
    public const int ENOTCONN = 126;
    public const int ENOTRECOVERABLE = 127;
    public const int ENOTSOCK = 128;
    public const int ENOTSUP = 129;
    public const int EOPNOTSUPP = 130;
    public const int EOTHER = 131;
    public const int EOVERFLOW = 132;
    public const int EOWNERDEAD = 133;
    public const int EPROTO = 134;
    public const int EPROTONOSUPPORT = 135;
    public const int EPROTOTYPE = 136;
    public const int ETIME = 137;
    public const int ETIMEDOUT = 138;
    public const int ETXTBSY = 139;
    public const int EWOULDBLOCK = 140;
}

public enum ErrorCodesEnum
{
    SUCCESS = 0,
    EPERM = 1,
    ENOENT = 2,
    ESRCH = 3,
    EINTR = 4,
    EIO = 5,
    ENXIO = 6,
    E2BIG = 7,
    ENOEXEC = 8,
    EBADF = 9,
    ECHILD = 10,
    EAGAIN = 11,
    ENOMEM = 12,
    EACCES = 13,
    EFAULT = 14,
    EBUSY = 16,
    EEXIST = 17,
    EXDEV = 18,
    ENODEV = 19,
    ENOTDIR = 20,
    EISDIR = 21,
    ENFILE = 23,
    EMFILE = 24,
    ENOTTY = 25,
    EFBIG = 27,
    ENOSPC = 28,
    ESPIPE = 29,
    EROFS = 30,
    EMLINK = 31,
    EPIPE = 32,
    EDOM = 33,
    EDEADLK = 36,
    ENAMETOOLONG = 38,
    ENOLCK = 39,
    ENOSYS = 40,
    ENOTEMPTY = 41,
    EINVAL = 22,
    ERANGE = 34,
    EILSEQ = 42,
    STRUNCATE = 80,
    EDEADLOCK = EDEADLK,
    EADDRINUSE = 100,
    EADDRNOTAVAIL = 101,
    EAFNOSUPPORT = 102,
    EALREADY = 103,
    EBADMSG = 104,
    ECANCELED = 105,
    ECONNABORTED = 106,
    ECONNREFUSED = 107,
    ECONNRESET = 108,
    EDESTADDRREQ = 109,
    EHOSTUNREACH = 110,
    EIDRM = 111,
    EINPROGRESS = 112,
    EISCONN = 113,
    ELOOP = 114,
    EMSGSIZE = 115,
    ENETDOWN = 116,
    ENETRESET = 117,
    ENETUNREACH = 118,
    ENOBUFS = 119,
    ENODATA = 120,
    ENOLINK = 121,
    ENOMSG = 122,
    ENOPROTOOPT = 123,
    ENOSR = 124,
    ENOSTR = 125,
    ENOTCONN = 126,
    ENOTRECOVERABLE = 127,
    ENOTSOCK = 128,
    ENOTSUP = 129,
    EOPNOTSUPP = 130,
    EOTHER = 131,
    EOVERFLOW = 132,
    EOWNERDEAD = 133,
    EPROTO = 134,
    EPROTONOSUPPORT = 135,
    EPROTOTYPE = 136,
    ETIME = 137,
    ETIMEDOUT = 138,
    ETXTBSY = 139,
    EWOULDBLOCK = 140
}