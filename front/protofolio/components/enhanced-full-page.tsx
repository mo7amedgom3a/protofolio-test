// EnhancedFullPage.tsx
"use client";
import { useCallback, useEffect, useState } from "react";
import { Button } from "@/components/ui/button";
import { useInView } from "react-intersection-observer";
import {
  HeartIcon,
  HomeIcon,
  UserIcon,
  BellIcon,
  SettingsIcon,
  BookmarkIcon,
  Loader2Icon,
} from "lucide-react";
import { CreatePost } from "./CreatePost";
import Post from "./Post";
import Sidebar from "./Sidebar";
import {
  renderProfilePage,
  renderNotificationsPage,
  renderSavedPostsPage,
  renderSettingsPage,
} from "./Pages"; // Import new pages
import SearchPage from "./search"; // Import search page
import { SearchIcon } from "lucide-react";

interface Comment {
  id: number;
  author: string;
  content: string;
}

interface Post {
  id: number;
  author: string;
  avatar: string;
  content: string;
  title: string;
  lang: string;
  code: string;
  images: string[];
  likes: number;
  comments: Comment[];
  saved: boolean;
  showComments: boolean;
  liked?: boolean;
}
export function EnhancedFullPage() {
  const [currentPage, setCurrentPage] = useState("home");

  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(false);
  const [hasMore, setHasMore] = useState(true);
  const [ref, inView] = useInView();
  const [posts, setPosts] = useState<Post[]>([
    {
      id: 1,
      author: "John Doe",
      avatar: "/placeholder-avatar.jpg",
      title: "React Hooks",
      images: [
        "https://miro.medium.com/v2/resize:fit:1100/format:webp/0*QR-44Cl9I4Y7pUYQ",
      ],
      lang: "javascript",
      content: "Just learned about React hooks. Game changer!",
      code: `const [count, setCount] = useState(0);
      
useEffect(() => {
  document.title = \`You clicked \${count} times\`;
}, [count]);`,
      likes: 42,
      comments: [
        {
          id: 1,
          author: "Jane Smith",
          content: "Totally agree! Hooks are amazing!",
        },
        {
          id: 2,
          author: "Bob Johnson",
          content: "Can you share more about how you're using them?",
        },
      ],
      saved: false,
      showComments: false,
    },
    {
      id: 2,
      author: "Jane Smith",
      title: "GraphQL",
      images: [
        "https://miro.medium.com/v2/resize:fit:1100/format:webp/0*QR-44Cl9I4Y7pUYQ",
      ],
      lang: "typescript",
      avatar: "/placeholder-avatar.jpg",
      content:
        "Anyone have experience with GraphQL? Thinking of using it in my next project.",
      code: `query {
  user(id: "123") {
    name
    email
    posts {
      title
    }
  }
}`,
      likes: 23,
      comments: [
        {
          id: 1,
          author: "Alice Williams",
          content:
            "I've used it in a few projects. It's great for reducing over-fetching!",
        },
      ],
      saved: false,
      showComments: false,
    },
  ]);
  const [newPost, setNewPost] = useState("");
  const [newPostCode, setNewPostCode] = useState("");

  const [title, setTitle] = useState("");
  const list_lang = [
    "c",
    "cpp",
    "java",
    "python",
    "javascript",
    "typescript",
    "html",
    "css",
    "shell",
    "powershell",
    "sql",
    "json",
    "yaml",
    "xml",
    "markdown",
    "plaintext",
  ];

  const loadMorePosts = useCallback(async () => {
    if (loading || !hasMore) return;
    setLoading(true);
    // Simulating an API call
    await new Promise((resolve) => setTimeout(resolve, 1000));
    const newPosts = Array(5)
      .fill(null)
      .map((_, index) => ({
        id: posts.length + index + 1,
        author: `User ${posts.length + index + 1}`,
        avatar: "/placeholder-avatar.jpg",
        title: `Post ${posts.length + index + 1}`,
        images: [],
        lang: "plaintext",
        content: `This is post number ${posts.length + index + 1}`,
        code: index % 2 === 0 ? `console.log('Hello, World!');` : "",
        likes: Math.floor(Math.random() * 100),
        comments: [],
        saved: false,
        showComments: false,
      }));
    setPosts((prevPosts) => [...prevPosts, ...newPosts]); // append new posts
    setPage((prevPage) => prevPage + 1); // increment page number
    setLoading(false);
  }, [loading, hasMore, posts, page]);

  useEffect(() => {
    if (inView) {
      loadMorePosts();
    }
  }, [inView, loadMorePosts]);

  const handlePostSubmit = ({
    title,
    content,
    code,
    lang,
    images,
  }: {
    title: string;
    content: string;
    code: string;
    lang: string;
    images: string[];
  }) => {
    if (content.trim()) {
      setPosts([
        {
          id: posts.length + 1,
          images,
          author: "You",
          avatar: "/placeholder-avatar.jpg",
          title,
          content,
          code,
          likes: 0,
          lang: lang,
          comments: [],
          saved: false,
          showComments: false,
        },
        ...posts,
      ]);
      setNewPost("");
      setNewPostCode("");
      setTitle("");
    }
  };

  const handleLike = (postId: number) => {
    setPosts(
      posts.map((post) =>
        post.id === postId
          ? {
              ...post,
              likes: post.liked ? post.likes - 1 : post.likes + 1,
              liked: !post.liked,
            }
          : post
      )
    );
  };

  const handleSave = (postId: number) => {
    setPosts(
      posts.map((post) =>
        post.id === postId ? { ...post, saved: !post.saved } : post
      )
    );
  };

  const handleShowComments = (postId: number) => {
    setPosts(
      posts.map((post) =>
        post.id === postId
          ? { ...post, showComments: !post.showComments }
          : post
      )
    );
  };

  const handleAddComment = (postId: number, comment: string) => {
    setPosts(
      posts.map((post) =>
        post.id === postId
          ? {
              ...post,
              comments: [
                ...post.comments,
                {
                  id: post.comments.length + 1,
                  author: "You",
                  content: comment,
                },
              ],
            }
          : post
      )
    );
  };

  const renderContent = () => {
    switch (currentPage) {
      case "profile":
        return renderProfilePage(); // Pass posts for user's posts
      case "notifications":
        return renderNotificationsPage();
      case "saved":
        return renderSavedPostsPage();
      case "settings":
        return renderSettingsPage();
      case "search":
        return <SearchPage />;
      default:
        return (
          <div className="max-w-2xl mx-auto p-4 space-y-4">
            <CreatePost
              newPost={newPost}
              newPostCode={newPostCode}
              setNewPost={setNewPost}
              setNewPostCode={setNewPostCode}
              onPostSubmit={handlePostSubmit}
              list_lang={list_lang}
            />
            {posts.map((post) => (
              <Post
                key={post.id}
                post={post}
                onLike={handleLike}
                onSave={handleSave}
                onShowComments={handleShowComments}
                onAddComment={handleAddComment}
              />
            ))}
            {hasMore && (
              <div ref={ref} className="flex justify-center p-4">
                {loading ? (
                  <Loader2Icon className="w-6 h-6 animate-spin" />
                ) : (
                  <Button onClick={loadMorePosts}>Load More</Button>
                )}
              </div>
            )}
          </div>
        );
    }
  };

  return (
    <div className="flex h-screen bg-gray-100">
      {/* Navbar */}
      <nav className="flex flex-col justify-between w-16 bg-white border-r border-gray-200">
        <div className="flex flex-col items-center pt-5 space-y-4">
          <Button
            variant="ghost"
            size="icon"
            aria-label="Home"
            onClick={() => setCurrentPage("home")}
          >
            <HomeIcon className="w-6 h-6" />
          </Button>
          <Button
            variant="ghost"
            size="icon"
            aria-label="Search"
            onClick={() => setCurrentPage("search")}
          >
            <SearchIcon className="w-6 h-6" />
          </Button>
          <Button
            variant="ghost"
            size="icon"
            aria-label="Profile"
            onClick={() => setCurrentPage("profile")}
          >
            <UserIcon className="w-6 h-6" />
          </Button>
          <Button
            variant="ghost"
            size="icon"
            aria-label="Notifications"
            onClick={() => setCurrentPage("notifications")}
          >
            <BellIcon className="w-6 h-6" />
          </Button>
          <Button
            variant="ghost"
            size="icon"
            aria-label="Saved Posts"
            onClick={() => setCurrentPage("saved")}
          >
            <BookmarkIcon className="w-6 h-6" />
          </Button>
        </div>
        <div className="pb-5">
          <Button
            variant="ghost"
            size="icon"
            aria-label="Settings"
            onClick={() => setCurrentPage("settings")}
          >
            <SettingsIcon className="w-6 h-6" />
          </Button>
        </div>
      </nav>

      {/* Main Content */}
      <main className="flex-1 overflow-auto">
        <header className="sticky top-0 z-10 bg-white border-b border-gray-200 p-4">
          <h1 className="text-2xl font-bold">Programmer's Social Hub ❤️</h1>
        </header>

        {renderContent()}
      </main>

      <Sidebar />
    </div>
  );
}
