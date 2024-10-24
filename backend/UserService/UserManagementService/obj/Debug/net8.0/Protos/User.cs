// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace UserManagementService.Grpc {

  /// <summary>Holder for reflection information generated from Protos/user.proto</summary>
  public static partial class UserReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/user.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFQcm90b3MvdXNlci5wcm90bxIEdXNlciIhCg5HZXRVc2VyUmVxdWVzdBIP",
            "Cgd1c2VyX2lkGAEgASgJIs4BCgxVc2VyUmVzcG9uc2USDwoHdXNlcl9pZBgB",
            "IAEoCRIQCgh1c2VybmFtZRgCIAEoCRIMCgRuYW1lGAMgASgJEg4KBmdlbmRl",
            "chgEIAEoCRILCgNiaW8YBSABKAkSCwoDYWdlGAYgASgFEg4KBnNraWxscxgH",
            "IAMoCRIaChJ0b3BpY3Nfb2ZfaW50ZXJlc3QYCCADKAkSEQoJaW1hZ2VfdXJs",
            "GAkgASgJEhEKCWZvbGxvd2VycxgKIAMoCRIRCglmb2xsb3dpbmcYCyADKAky",
            "RgoLVXNlclNlcnZpY2USNwoLR2V0VXNlckJ5SWQSFC51c2VyLkdldFVzZXJS",
            "ZXF1ZXN0GhIudXNlci5Vc2VyUmVzcG9uc2VCHaoCGlVzZXJNYW5hZ2VtZW50",
            "U2VydmljZS5HcnBjYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::UserManagementService.Grpc.GetUserRequest), global::UserManagementService.Grpc.GetUserRequest.Parser, new[]{ "UserId" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::UserManagementService.Grpc.UserResponse), global::UserManagementService.Grpc.UserResponse.Parser, new[]{ "UserId", "Username", "Name", "Gender", "Bio", "Age", "Skills", "TopicsOfInterest", "ImageUrl", "Followers", "Following" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class GetUserRequest : pb::IMessage<GetUserRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetUserRequest> _parser = new pb::MessageParser<GetUserRequest>(() => new GetUserRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetUserRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UserManagementService.Grpc.UserReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetUserRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetUserRequest(GetUserRequest other) : this() {
      userId_ = other.userId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetUserRequest Clone() {
      return new GetUserRequest(this);
    }

    /// <summary>Field number for the "user_id" field.</summary>
    public const int UserIdFieldNumber = 1;
    private string userId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UserId {
      get { return userId_; }
      set {
        userId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetUserRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetUserRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId.Length != 0) hash ^= UserId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (UserId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (UserId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (UserId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetUserRequest other) {
      if (other == null) {
        return;
      }
      if (other.UserId.Length != 0) {
        UserId = other.UserId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            UserId = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            UserId = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class UserResponse : pb::IMessage<UserResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<UserResponse> _parser = new pb::MessageParser<UserResponse>(() => new UserResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<UserResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UserManagementService.Grpc.UserReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserResponse(UserResponse other) : this() {
      userId_ = other.userId_;
      username_ = other.username_;
      name_ = other.name_;
      gender_ = other.gender_;
      bio_ = other.bio_;
      age_ = other.age_;
      skills_ = other.skills_.Clone();
      topicsOfInterest_ = other.topicsOfInterest_.Clone();
      imageUrl_ = other.imageUrl_;
      followers_ = other.followers_.Clone();
      following_ = other.following_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserResponse Clone() {
      return new UserResponse(this);
    }

    /// <summary>Field number for the "user_id" field.</summary>
    public const int UserIdFieldNumber = 1;
    private string userId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UserId {
      get { return userId_; }
      set {
        userId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "username" field.</summary>
    public const int UsernameFieldNumber = 2;
    private string username_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Username {
      get { return username_; }
      set {
        username_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "gender" field.</summary>
    public const int GenderFieldNumber = 4;
    private string gender_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Gender {
      get { return gender_; }
      set {
        gender_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "bio" field.</summary>
    public const int BioFieldNumber = 5;
    private string bio_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Bio {
      get { return bio_; }
      set {
        bio_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "age" field.</summary>
    public const int AgeFieldNumber = 6;
    private int age_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Age {
      get { return age_; }
      set {
        age_ = value;
      }
    }

    /// <summary>Field number for the "skills" field.</summary>
    public const int SkillsFieldNumber = 7;
    private static readonly pb::FieldCodec<string> _repeated_skills_codec
        = pb::FieldCodec.ForString(58);
    private readonly pbc::RepeatedField<string> skills_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> Skills {
      get { return skills_; }
    }

    /// <summary>Field number for the "topics_of_interest" field.</summary>
    public const int TopicsOfInterestFieldNumber = 8;
    private static readonly pb::FieldCodec<string> _repeated_topicsOfInterest_codec
        = pb::FieldCodec.ForString(66);
    private readonly pbc::RepeatedField<string> topicsOfInterest_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> TopicsOfInterest {
      get { return topicsOfInterest_; }
    }

    /// <summary>Field number for the "image_url" field.</summary>
    public const int ImageUrlFieldNumber = 9;
    private string imageUrl_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ImageUrl {
      get { return imageUrl_; }
      set {
        imageUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "followers" field.</summary>
    public const int FollowersFieldNumber = 10;
    private static readonly pb::FieldCodec<string> _repeated_followers_codec
        = pb::FieldCodec.ForString(82);
    private readonly pbc::RepeatedField<string> followers_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> Followers {
      get { return followers_; }
    }

    /// <summary>Field number for the "following" field.</summary>
    public const int FollowingFieldNumber = 11;
    private static readonly pb::FieldCodec<string> _repeated_following_codec
        = pb::FieldCodec.ForString(90);
    private readonly pbc::RepeatedField<string> following_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> Following {
      get { return following_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as UserResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(UserResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      if (Username != other.Username) return false;
      if (Name != other.Name) return false;
      if (Gender != other.Gender) return false;
      if (Bio != other.Bio) return false;
      if (Age != other.Age) return false;
      if(!skills_.Equals(other.skills_)) return false;
      if(!topicsOfInterest_.Equals(other.topicsOfInterest_)) return false;
      if (ImageUrl != other.ImageUrl) return false;
      if(!followers_.Equals(other.followers_)) return false;
      if(!following_.Equals(other.following_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId.Length != 0) hash ^= UserId.GetHashCode();
      if (Username.Length != 0) hash ^= Username.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Gender.Length != 0) hash ^= Gender.GetHashCode();
      if (Bio.Length != 0) hash ^= Bio.GetHashCode();
      if (Age != 0) hash ^= Age.GetHashCode();
      hash ^= skills_.GetHashCode();
      hash ^= topicsOfInterest_.GetHashCode();
      if (ImageUrl.Length != 0) hash ^= ImageUrl.GetHashCode();
      hash ^= followers_.GetHashCode();
      hash ^= following_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (UserId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserId);
      }
      if (Username.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Username);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Gender.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Gender);
      }
      if (Bio.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Bio);
      }
      if (Age != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Age);
      }
      skills_.WriteTo(output, _repeated_skills_codec);
      topicsOfInterest_.WriteTo(output, _repeated_topicsOfInterest_codec);
      if (ImageUrl.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(ImageUrl);
      }
      followers_.WriteTo(output, _repeated_followers_codec);
      following_.WriteTo(output, _repeated_following_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (UserId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserId);
      }
      if (Username.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Username);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Gender.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Gender);
      }
      if (Bio.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Bio);
      }
      if (Age != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Age);
      }
      skills_.WriteTo(ref output, _repeated_skills_codec);
      topicsOfInterest_.WriteTo(ref output, _repeated_topicsOfInterest_codec);
      if (ImageUrl.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(ImageUrl);
      }
      followers_.WriteTo(ref output, _repeated_followers_codec);
      following_.WriteTo(ref output, _repeated_following_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (UserId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserId);
      }
      if (Username.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Gender.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Gender);
      }
      if (Bio.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Bio);
      }
      if (Age != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Age);
      }
      size += skills_.CalculateSize(_repeated_skills_codec);
      size += topicsOfInterest_.CalculateSize(_repeated_topicsOfInterest_codec);
      if (ImageUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ImageUrl);
      }
      size += followers_.CalculateSize(_repeated_followers_codec);
      size += following_.CalculateSize(_repeated_following_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(UserResponse other) {
      if (other == null) {
        return;
      }
      if (other.UserId.Length != 0) {
        UserId = other.UserId;
      }
      if (other.Username.Length != 0) {
        Username = other.Username;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Gender.Length != 0) {
        Gender = other.Gender;
      }
      if (other.Bio.Length != 0) {
        Bio = other.Bio;
      }
      if (other.Age != 0) {
        Age = other.Age;
      }
      skills_.Add(other.skills_);
      topicsOfInterest_.Add(other.topicsOfInterest_);
      if (other.ImageUrl.Length != 0) {
        ImageUrl = other.ImageUrl;
      }
      followers_.Add(other.followers_);
      following_.Add(other.following_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            UserId = input.ReadString();
            break;
          }
          case 18: {
            Username = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 34: {
            Gender = input.ReadString();
            break;
          }
          case 42: {
            Bio = input.ReadString();
            break;
          }
          case 48: {
            Age = input.ReadInt32();
            break;
          }
          case 58: {
            skills_.AddEntriesFrom(input, _repeated_skills_codec);
            break;
          }
          case 66: {
            topicsOfInterest_.AddEntriesFrom(input, _repeated_topicsOfInterest_codec);
            break;
          }
          case 74: {
            ImageUrl = input.ReadString();
            break;
          }
          case 82: {
            followers_.AddEntriesFrom(input, _repeated_followers_codec);
            break;
          }
          case 90: {
            following_.AddEntriesFrom(input, _repeated_following_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            UserId = input.ReadString();
            break;
          }
          case 18: {
            Username = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 34: {
            Gender = input.ReadString();
            break;
          }
          case 42: {
            Bio = input.ReadString();
            break;
          }
          case 48: {
            Age = input.ReadInt32();
            break;
          }
          case 58: {
            skills_.AddEntriesFrom(ref input, _repeated_skills_codec);
            break;
          }
          case 66: {
            topicsOfInterest_.AddEntriesFrom(ref input, _repeated_topicsOfInterest_codec);
            break;
          }
          case 74: {
            ImageUrl = input.ReadString();
            break;
          }
          case 82: {
            followers_.AddEntriesFrom(ref input, _repeated_followers_codec);
            break;
          }
          case 90: {
            following_.AddEntriesFrom(ref input, _repeated_following_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
